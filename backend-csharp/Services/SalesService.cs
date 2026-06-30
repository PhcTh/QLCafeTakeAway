using backend_csharp.Data;
using backend_csharp.Models;
using Microsoft.Data.SqlClient;

namespace backend_csharp.Services;

public sealed class SalesService
{
    private readonly DbConnectionFactory _db;

    public SalesService(DbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<PhieuGoiDoUongDto>> GetPhieuGoiAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT so_pgdu
            FROM P_G_DU
            WHERE @keyword IS NULL
               OR so_pgdu LIKE @like
               OR ma_kh LIKE @like
               OR tenkhachhang LIKE @like
            ORDER BY ngaygoiduong DESC, thoigiangoiduong DESC, so_pgdu DESC
            """;

        var ids = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => reader.GetString("so_pgdu"));

        var result = new List<PhieuGoiDoUongDto>();
        foreach (var id in ids)
        {
            var item = await GetPhieuGoiByIdAsync(id);
            if (item is not null)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public async Task<PhieuGoiDoUongDto?> GetPhieuGoiByIdAsync(string soPgdu)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string headerSql = """
            SELECT so_pgdu, ma_kh, ngaygoiduong, thoigiangoiduong, tenkhachhang, tennd, ma_nd
            FROM P_G_DU
            WHERE so_pgdu = @so_pgdu
            """;

        var headers = await SqlHelpers.QueryAsync(
            connection,
            headerSql,
            cmd => cmd.AddParam("@so_pgdu", soPgdu),
            reader => new
            {
                SoPgdu = reader.GetString("so_pgdu"),
                MaKh = reader.GetString("ma_kh"),
                Ngay = reader.GetDateOnly("ngaygoiduong"),
                Gio = reader.GetTimeOnly("thoigiangoiduong"),
                TenKhachHang = reader.GetNullableString("tenkhachhang") ?? string.Empty,
                TenNhanVien = reader.GetString("tennd"),
                MaNd = reader.GetString("ma_nd")
            });

        var header = headers.FirstOrDefault();
        if (header is null)
        {
            return null;
        }

        var details = await GetPhieuGoiDetailsAsync(connection, soPgdu);
        return new PhieuGoiDoUongDto(
            header.SoPgdu,
            header.MaKh,
            header.TenKhachHang,
            header.Ngay,
            header.Gio,
            header.TenNhanVien,
            header.MaNd,
            details);
    }

    public async Task CreatePhieuGoiAsync(CreatePhieuGoiRequest request)
    {
        ValidatePhieuGoi(request);

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            const string headerSql = """
                INSERT INTO P_G_DU
                    (so_pgdu, ma_kh, ngaygoiduong, thoigiangoiduong, tenkhachhang, tennd, ma_nd)
                VALUES
                    (@so_pgdu, @ma_kh, @ngaygoiduong, @thoigiangoiduong, @tenkhachhang, @tennd, @ma_nd)
                """;

            await SqlHelpers.ExecuteAsync(connection, headerSql, cmd =>
            {
                cmd.AddParam("@so_pgdu", request.SoPgdu);
                cmd.AddParam("@ma_kh", request.MaKh);
                cmd.AddParam("@ngaygoiduong", ToDateTime(request.NgayGoiDoUong));
                cmd.AddParam("@thoigiangoiduong", request.ThoiGianGoiDoUong.ToTimeSpan());
                cmd.AddParam("@tenkhachhang", request.TenKhachHang);
                cmd.AddParam("@tennd", request.TenNhanVien);
                cmd.AddParam("@ma_nd", request.MaNd);
            }, transaction);

            foreach (var detail in request.ChiTiet)
            {
                await InsertPhieuGoiDetailAsync(connection, transaction, request.SoPgdu, detail);
            }

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> UpdatePhieuGoiAsync(string soPgdu, CreatePhieuGoiRequest request)
    {
        ValidatePhieuGoi(request);

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            const string updateSql = """
                UPDATE P_G_DU
                SET ma_kh = @ma_kh,
                    ngaygoiduong = @ngaygoiduong,
                    thoigiangoiduong = @thoigiangoiduong,
                    tenkhachhang = @tenkhachhang,
                    tennd = @tennd,
                    ma_nd = @ma_nd
                WHERE so_pgdu = @so_pgdu
                """;

            var affected = await SqlHelpers.ExecuteAsync(connection, updateSql, cmd =>
            {
                cmd.AddParam("@so_pgdu", soPgdu);
                cmd.AddParam("@ma_kh", request.MaKh);
                cmd.AddParam("@ngaygoiduong", ToDateTime(request.NgayGoiDoUong));
                cmd.AddParam("@thoigiangoiduong", request.ThoiGianGoiDoUong.ToTimeSpan());
                cmd.AddParam("@tenkhachhang", request.TenKhachHang);
                cmd.AddParam("@tennd", request.TenNhanVien);
                cmd.AddParam("@ma_nd", request.MaNd);
            }, transaction);

            if (affected == 0)
            {
                await transaction.RollbackAsync();
                return false;
            }

            await SqlHelpers.ExecuteAsync(
                connection,
                "DELETE FROM C_T_PGDU WHERE so_pgdu = @so_pgdu",
                cmd => cmd.AddParam("@so_pgdu", soPgdu),
                transaction);

            foreach (var detail in request.ChiTiet)
            {
                await InsertPhieuGoiDetailAsync(connection, transaction, soPgdu, detail);
            }

            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> DeletePhieuGoiAsync(string soPgdu)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            await SqlHelpers.ExecuteAsync(
                connection,
                "DELETE FROM C_T_PGDU WHERE so_pgdu = @so_pgdu",
                cmd => cmd.AddParam("@so_pgdu", soPgdu),
                transaction);

            var affected = await SqlHelpers.ExecuteAsync(
                connection,
                "DELETE FROM P_G_DU WHERE so_pgdu = @so_pgdu",
                cmd => cmd.AddParam("@so_pgdu", soPgdu),
                transaction);

            await transaction.CommitAsync();
            return affected > 0;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IReadOnlyList<HoaDonDto>> GetHoaDonAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT so_hdbdu
            FROM HD_BDUONG
            WHERE @keyword IS NULL
               OR so_hdbdu LIKE @like
               OR ma_khachhang LIKE @like
               OR so_pgdu LIKE @like
               OR hinhthucthanhtoan LIKE @like
               OR trangthai LIKE @like
            ORDER BY ngaylaphoadon DESC, thoigianthanhtoan DESC, so_hdbdu DESC
            """;

        var ids = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => reader.GetString("so_hdbdu"));

        var result = new List<HoaDonDto>();
        foreach (var id in ids)
        {
            var item = await GetHoaDonByIdAsync(id);
            if (item is not null)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public async Task<HoaDonDto?> GetHoaDonByIdAsync(string soHdbdu)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string headerSql = """
            SELECT hd.so_hdbdu, hd.ma_khachhang, kh.tenkhachhang, hd.so_pgdu,
                   hd.ngaylaphoadon, hd.thoigianthanhtoan, hd.hinhthucthanhtoan,
                   hd.trangthai, hd.ghichu, hd.nguoilaphoadon, hd.tennd, hd.ma_nd
            FROM HD_BDUONG hd
            INNER JOIN K_H kh ON kh.ma_kh = hd.ma_khachhang
            WHERE hd.so_hdbdu = @so_hdbdu
            """;

        var headers = await SqlHelpers.QueryAsync(
            connection,
            headerSql,
            cmd => cmd.AddParam("@so_hdbdu", soHdbdu),
            reader => new
            {
                SoHdbdu = reader.GetString("so_hdbdu"),
                MaKhachHang = reader.GetString("ma_khachhang"),
                TenKhachHang = reader.GetString("tenkhachhang"),
                SoPgdu = reader.GetString("so_pgdu"),
                Ngay = reader.GetDateOnly("ngaylaphoadon"),
                Gio = reader.GetTimeOnly("thoigianthanhtoan"),
                HinhThucThanhToan = reader.GetString("hinhthucthanhtoan"),
                TrangThai = reader.GetString("trangthai"),
                GhiChu = reader.GetNullableString("ghichu"),
                NguoiLapHoaDon = reader.GetString("nguoilaphoadon"),
                TenNhanVien = reader.GetString("tennd"),
                MaNd = reader.GetString("ma_nd")
            });

        var header = headers.FirstOrDefault();
        if (header is null)
        {
            return null;
        }

        var details = await GetHoaDonDetailsAsync(connection, soHdbdu);
        return new HoaDonDto(
            header.SoHdbdu,
            header.MaKhachHang,
            header.TenKhachHang,
            header.SoPgdu,
            header.Ngay,
            header.Gio,
            header.HinhThucThanhToan,
            header.TrangThai,
            header.GhiChu,
            header.NguoiLapHoaDon,
            header.TenNhanVien,
            header.MaNd,
            details.Sum(x => x.ThanhTien),
            details);
    }

    public async Task CreateHoaDonAsync(CreateHoaDonRequest request)
    {
        EnsureRequired(request.SoHdbdu, nameof(request.SoHdbdu));
        EnsureRequired(request.MaKhachHang, nameof(request.MaKhachHang));
        EnsureRequired(request.SoPgdu, nameof(request.SoPgdu));
        EnsureRequired(request.HinhThucThanhToan, nameof(request.HinhThucThanhToan));
        EnsureRequired(request.TrangThai, nameof(request.TrangThai));
        EnsureRequired(request.NguoiLapHoaDon, nameof(request.NguoiLapHoaDon));
        EnsureRequired(request.TenNhanVien, nameof(request.TenNhanVien));
        EnsureRequired(request.MaNd, nameof(request.MaNd));

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            var details = request.ChiTiet is { Count: > 0 }
                ? request.ChiTiet.ToList()
                : await LoadInvoiceDetailsFromOrderAsync(connection, transaction, request.SoPgdu);

            if (details.Count == 0)
            {
                throw new ArgumentException("Invoice requires at least one drink detail.");
            }

            var enrichedDetails = new List<ChiTietHoaDonDto>();
            foreach (var detail in details)
            {
                var drink = await GetDrinkSnapshotAsync(connection, transaction, detail.MaDu);
                var thanhTien = detail.SoLuongBan * drink.DonGia;
                enrichedDetails.Add(new ChiTietHoaDonDto(
                    detail.MaDu,
                    drink.TenDoUong,
                    detail.Size,
                    detail.SoLuongBan,
                    drink.DonGia,
                    thanhTien));
            }

            var first = enrichedDetails[0];

            const string headerSql = """
                INSERT INTO HD_BDUONG
                    (so_hdbdu, ma_khachhang, so_pgdu, ngaylaphoadon, thoigianthanhtoan,
                     hinhthucthanhtoan, trangthai, ghichu, nguoilaphoadon,
                     ma_du, soluongban, tendouong, thanhtien, tennd, ma_nd)
                VALUES
                    (@so_hdbdu, @ma_khachhang, @so_pgdu, @ngaylaphoadon, @thoigianthanhtoan,
                     @hinhthucthanhtoan, @trangthai, @ghichu, @nguoilaphoadon,
                     @ma_du, @soluongban, @tendouong, @thanhtien, @tennd, @ma_nd)
                """;

            await SqlHelpers.ExecuteAsync(connection, headerSql, cmd =>
            {
                cmd.AddParam("@so_hdbdu", request.SoHdbdu);
                cmd.AddParam("@ma_khachhang", request.MaKhachHang);
                cmd.AddParam("@so_pgdu", request.SoPgdu);
                cmd.AddParam("@ngaylaphoadon", ToDateTime(request.NgayLapHoaDon));
                cmd.AddParam("@thoigianthanhtoan", request.ThoiGianThanhToan.ToTimeSpan());
                cmd.AddParam("@hinhthucthanhtoan", request.HinhThucThanhToan);
                cmd.AddParam("@trangthai", request.TrangThai);
                cmd.AddParam("@ghichu", request.GhiChu);
                cmd.AddParam("@nguoilaphoadon", request.NguoiLapHoaDon);
                cmd.AddParam("@ma_du", first.MaDu);
                cmd.AddParam("@soluongban", first.SoLuongBan);
                cmd.AddParam("@tendouong", first.TenDoUong);
                cmd.AddParam("@thanhtien", first.ThanhTien);
                cmd.AddParam("@tennd", request.TenNhanVien);
                cmd.AddParam("@ma_nd", request.MaNd);
            }, transaction);

            const string detailSql = """
                INSERT INTO C_T_HDBDU (so_hdbdu, ma_du, size, soluongban, thanhtien)
                VALUES (@so_hdbdu, @ma_du, @size, @soluongban, @thanhtien)
                """;

            foreach (var detail in enrichedDetails)
            {
                await SqlHelpers.ExecuteAsync(connection, detailSql, cmd =>
                {
                    cmd.AddParam("@so_hdbdu", request.SoHdbdu);
                    cmd.AddParam("@ma_du", detail.MaDu);
                    cmd.AddParam("@size", detail.Size);
                    cmd.AddParam("@soluongban", detail.SoLuongBan);
                    cmd.AddParam("@thanhtien", detail.ThanhTien);
                }, transaction);
            }

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> DeleteHoaDonAsync(string soHdbdu)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            await SqlHelpers.ExecuteAsync(
                connection,
                "DELETE FROM C_T_HDBDU WHERE so_hdbdu = @so_hdbdu",
                cmd => cmd.AddParam("@so_hdbdu", soHdbdu),
                transaction);

            var affected = await SqlHelpers.ExecuteAsync(
                connection,
                "DELETE FROM HD_BDUONG WHERE so_hdbdu = @so_hdbdu",
                cmd => cmd.AddParam("@so_hdbdu", soHdbdu),
                transaction);

            await transaction.CommitAsync();
            return affected > 0;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private static async Task InsertPhieuGoiDetailAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        string soPgdu,
        CreateChiTietPhieuGoiRequest detail)
    {
        EnsureRequired(detail.MaDu, nameof(detail.MaDu));
        EnsureRequired(detail.Size, nameof(detail.Size));
        EnsurePositive(detail.SoLuongGoi, nameof(detail.SoLuongGoi));

        const string sql = """
            INSERT INTO C_T_PGDU (ma_du, so_pgdu, size, soluonggoi, yeucaudacbiet)
            VALUES (@ma_du, @so_pgdu, @size, @soluonggoi, @yeucaudacbiet)
            """;

        await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@ma_du", detail.MaDu);
            cmd.AddParam("@so_pgdu", soPgdu);
            cmd.AddParam("@size", detail.Size);
            cmd.AddParam("@soluonggoi", detail.SoLuongGoi);
            cmd.AddParam("@yeucaudacbiet", detail.YeuCauDacBiet);
        }, transaction);
    }

    private static async Task<IReadOnlyList<ChiTietPhieuGoiDto>> GetPhieuGoiDetailsAsync(SqlConnection connection, string soPgdu)
    {
        const string detailSql = """
            SELECT ct.ma_du, du.tendouong, ct.size, ct.soluonggoi,
                   ct.yeucaudacbiet, du.dongia,
                   ct.soluonggoi * du.dongia AS thanhtien
            FROM C_T_PGDU ct
            INNER JOIN DU du ON du.ma_du = ct.ma_du
            WHERE ct.so_pgdu = @so_pgdu
            ORDER BY ct.ma_du, ct.size
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            detailSql,
            cmd => cmd.AddParam("@so_pgdu", soPgdu),
            reader => new ChiTietPhieuGoiDto(
                reader.GetString("ma_du"),
                reader.GetString("tendouong"),
                reader.GetString("size"),
                reader.GetInt("soluonggoi"),
                reader.GetNullableString("yeucaudacbiet"),
                reader.GetDecimal("dongia"),
                reader.GetDecimal("thanhtien")));
    }

    private static async Task<IReadOnlyList<ChiTietHoaDonDto>> GetHoaDonDetailsAsync(SqlConnection connection, string soHdbdu)
    {
        const string detailSql = """
            SELECT ct.ma_du, du.tendouong, ct.size, ct.soluongban,
                   du.dongia, ct.thanhtien
            FROM C_T_HDBDU ct
            INNER JOIN DU du ON du.ma_du = ct.ma_du
            WHERE ct.so_hdbdu = @so_hdbdu
            ORDER BY ct.ma_du, ct.size
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            detailSql,
            cmd => cmd.AddParam("@so_hdbdu", soHdbdu),
            reader => new ChiTietHoaDonDto(
                reader.GetString("ma_du"),
                reader.GetString("tendouong"),
                reader.GetString("size"),
                reader.GetInt("soluongban"),
                reader.GetDecimal("dongia"),
                reader.GetDecimal("thanhtien")));
    }

    private static async Task<List<CreateChiTietHoaDonRequest>> LoadInvoiceDetailsFromOrderAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        string soPgdu)
    {
        const string sql = """
            SELECT ma_du, size, soluonggoi
            FROM C_T_PGDU
            WHERE so_pgdu = @so_pgdu
            ORDER BY ma_du, size
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => cmd.AddParam("@so_pgdu", soPgdu),
            reader => new CreateChiTietHoaDonRequest(
                reader.GetString("ma_du"),
                reader.GetString("size"),
                reader.GetInt("soluonggoi")),
            transaction);
    }

    private static async Task<(string TenDoUong, decimal DonGia)> GetDrinkSnapshotAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        string maDu)
    {
        const string sql = "SELECT tendouong, dongia FROM DU WHERE ma_du = @ma_du";
        var rows = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => cmd.AddParam("@ma_du", maDu),
            reader => (reader.GetString("tendouong"), reader.GetDecimal("dongia")),
            transaction);

        return rows.FirstOrDefault() == default
            ? throw new ArgumentException($"Drink {maDu} does not exist.")
            : rows[0];
    }

    private static void ValidatePhieuGoi(CreatePhieuGoiRequest request)
    {
        EnsureRequired(request.SoPgdu, nameof(request.SoPgdu));
        EnsureRequired(request.MaKh, nameof(request.MaKh));
        EnsureRequired(request.TenNhanVien, nameof(request.TenNhanVien));
        EnsureRequired(request.MaNd, nameof(request.MaNd));

        if (request.ChiTiet.Count == 0)
        {
            throw new ArgumentException("Order requires at least one drink detail.");
        }
    }

    private static DateTime ToDateTime(DateOnly date)
    {
        return date.ToDateTime(TimeOnly.MinValue);
    }

    private static void BindKeyword(SqlCommand cmd, string? keyword)
    {
        var normalized = string.IsNullOrWhiteSpace(keyword) ? null : keyword.Trim();
        cmd.AddParam("@keyword", normalized);
        cmd.AddParam("@like", normalized is null ? null : $"%{normalized}%");
    }

    private static void EnsureRequired(string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{name} is required.");
        }
    }

    private static void EnsurePositive(int value, string name)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{name} must be greater than 0.");
        }
    }
}
