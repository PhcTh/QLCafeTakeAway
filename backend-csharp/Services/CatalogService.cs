using backend_csharp.Data;
using backend_csharp.Models;
using backend_csharp.Security;

namespace backend_csharp.Services;

public sealed class CatalogService
{
    private readonly DbConnectionFactory _db;

    public CatalogService(DbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<LoaiDoUongDto>> GetLoaiDoUongAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT ma_ldu, tenloaidouong, mota
            FROM LDU
            WHERE trangthai = 1
              AND (@keyword IS NULL
               OR ma_ldu LIKE @like
               OR tenloaidouong LIKE @like)
            ORDER BY ma_ldu
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => new LoaiDoUongDto(
                reader.GetString("ma_ldu"),
                reader.GetString("tenloaidouong"),
                reader.GetNullableString("mota")));
    }

    public async Task<LoaiDoUongDto?> GetLoaiDoUongByIdAsync(string id)
    {
        var rows = await GetLoaiDoUongAsync(id);
        return rows.FirstOrDefault(x => x.MaLdu.Equals(id, StringComparison.OrdinalIgnoreCase));
    }

    public async Task CreateLoaiDoUongAsync(UpsertLoaiDoUongRequest request)
    {
        EnsureRequired(request.MaLdu, nameof(request.MaLdu));
        EnsureRequired(request.TenLoaiDoUong, nameof(request.TenLoaiDoUong));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            INSERT INTO LDU (ma_ldu, tenloaidouong, mota)
            VALUES (@ma_ldu, @tenloaidouong, @mota)
            """;

        await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@ma_ldu", request.MaLdu);
            cmd.AddParam("@tenloaidouong", request.TenLoaiDoUong);
            cmd.AddParam("@mota", request.MoTa);
        });
    }

    public async Task<bool> UpdateLoaiDoUongAsync(string id, UpsertLoaiDoUongRequest request)
    {
        EnsureRequired(request.TenLoaiDoUong, nameof(request.TenLoaiDoUong));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            UPDATE LDU
            SET tenloaidouong = @tenloaidouong,
                mota = @mota
            WHERE ma_ldu = @ma_ldu AND trangthai = 1
            """;

        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@ma_ldu", id);
            cmd.AddParam("@tenloaidouong", request.TenLoaiDoUong);
            cmd.AddParam("@mota", request.MoTa);
        });

        return affected > 0;
    }

    public Task<bool> DeleteLoaiDoUongAsync(string id)
    {
        return DeleteWithChecksAsync(
            "UPDATE LDU SET trangthai = 0 WHERE ma_ldu = @id AND trangthai = 1",
            id,
            new ReferenceCheck(
                "SELECT COUNT(1) FROM DU WHERE ma_ldu = @id AND trangthai = 1",
                "Không thể xóa loại đồ uống này vì vẫn còn đồ uống thuộc loại này."));
    }

    public async Task<IReadOnlyList<DoUongDto>> GetDoUongAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT du.ma_du, du.ma_ldu, ldu.tenloaidouong, du.tendouong, du.dongia
            FROM DU du
            INNER JOIN LDU ldu ON ldu.ma_ldu = du.ma_ldu
            WHERE du.trangthai = 1
              AND ldu.trangthai = 1
              AND (@keyword IS NULL
               OR du.ma_du LIKE @like
               OR du.tendouong LIKE @like
               OR ldu.tenloaidouong LIKE @like)
            ORDER BY du.ma_du
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            MapDoUong);
    }

    public async Task<DoUongDto?> GetDoUongByIdAsync(string id)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT du.ma_du, du.ma_ldu, ldu.tenloaidouong, du.tendouong, du.dongia
            FROM DU du
            INNER JOIN LDU ldu ON ldu.ma_ldu = du.ma_ldu
            WHERE du.ma_du = @id AND du.trangthai = 1
            """;

        var rows = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => cmd.AddParam("@id", id),
            MapDoUong);

        return rows.FirstOrDefault();
    }

    public async Task CreateDoUongAsync(UpsertDoUongRequest request)
    {
        EnsureRequired(request.MaDu, nameof(request.MaDu));
        EnsureRequired(request.MaLdu, nameof(request.MaLdu));
        EnsureRequired(request.TenDoUong, nameof(request.TenDoUong));
        EnsurePositive(request.DonGia, nameof(request.DonGia));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            INSERT INTO DU (ma_du, ma_ldu, tendouong, dongia)
            VALUES (@ma_du, @ma_ldu, @tendouong, @dongia)
            """;

        await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@ma_du", request.MaDu);
            cmd.AddParam("@ma_ldu", request.MaLdu);
            cmd.AddParam("@tendouong", request.TenDoUong);
            cmd.AddParam("@dongia", request.DonGia);
        });
    }

    public async Task<bool> UpdateDoUongAsync(string id, UpsertDoUongRequest request)
    {
        EnsureRequired(request.MaLdu, nameof(request.MaLdu));
        EnsureRequired(request.TenDoUong, nameof(request.TenDoUong));
        EnsurePositive(request.DonGia, nameof(request.DonGia));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            UPDATE DU
            SET ma_ldu = @ma_ldu,
                tendouong = @tendouong,
                dongia = @dongia
            WHERE ma_du = @ma_du AND trangthai = 1
            """;

        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@ma_du", id);
            cmd.AddParam("@ma_ldu", request.MaLdu);
            cmd.AddParam("@tendouong", request.TenDoUong);
            cmd.AddParam("@dongia", request.DonGia);
        });

        return affected > 0;
    }

    public Task<bool> DeleteDoUongAsync(string id)
    {
        return DeleteWithChecksAsync(
            "UPDATE DU SET trangthai = 0 WHERE ma_du = @id AND trangthai = 1",
            id,
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa đồ uống này vì đã có trong hóa đơn bán hàng."),
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa đồ uống này vì đã có trong phiếu gọi đồ uống."),
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa đồ uống này vì đang có khai báo nguyên liệu/công thức."));
    }

    public async Task<IReadOnlyList<NguyenLieuDto>> GetNguyenLieuAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT ma_nl, tennguyenlieu, donvitinh
            FROM NL
            WHERE trangthai = 1
              AND (@keyword IS NULL
               OR ma_nl LIKE @like
               OR tennguyenlieu LIKE @like)
            ORDER BY ma_nl
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => new NguyenLieuDto(
                reader.GetString("ma_nl"),
                reader.GetString("tennguyenlieu"),
                reader.GetString("donvitinh")));
    }

    public async Task CreateNguyenLieuAsync(UpsertNguyenLieuRequest request)
    {
        EnsureRequired(request.MaNl, nameof(request.MaNl));
        EnsureRequired(request.TenNguyenLieu, nameof(request.TenNguyenLieu));
        EnsureRequired(request.DonViTinh, nameof(request.DonViTinh));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = "INSERT INTO NL (ma_nl, tennguyenlieu, donvitinh) VALUES (@ma_nl, @tennguyenlieu, @donvitinh)";
        await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@ma_nl", request.MaNl);
            cmd.AddParam("@tennguyenlieu", request.TenNguyenLieu);
            cmd.AddParam("@donvitinh", request.DonViTinh);
        });
    }

    public async Task<bool> UpdateNguyenLieuAsync(string id, UpsertNguyenLieuRequest request)
    {
        EnsureRequired(request.TenNguyenLieu, nameof(request.TenNguyenLieu));
        EnsureRequired(request.DonViTinh, nameof(request.DonViTinh));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = "UPDATE NL SET tennguyenlieu = @tennguyenlieu, donvitinh = @donvitinh WHERE ma_nl = @ma_nl AND trangthai = 1";
        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@ma_nl", id);
            cmd.AddParam("@tennguyenlieu", request.TenNguyenLieu);
            cmd.AddParam("@donvitinh", request.DonViTinh);
        });

        return affected > 0;
    }

    public Task<bool> DeleteNguyenLieuAsync(string id)
    {
        return DeleteWithChecksAsync(
            "UPDATE NL SET trangthai = 0 WHERE ma_nl = @id AND trangthai = 1",
            id,
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa nguyên liệu này vì đã có trong đơn nguyên liệu mua."),
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa nguyên liệu này vì đã có trong phiếu nhập hàng."),
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa nguyên liệu này vì đã có trong phiếu kiểm kê."),
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa nguyên liệu này vì đang được dùng trong công thức đồ uống."));
    }

    public async Task<IReadOnlyList<KhachHangDto>> GetKhachHangAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT ma_kh, tenkhachhang, sodienthoai, diachi, gioitinh
            FROM K_H
            WHERE trangthai = 1
              AND (@keyword IS NULL
               OR ma_kh LIKE @like
               OR tenkhachhang LIKE @like
               OR sodienthoai LIKE @like)
            ORDER BY ma_kh
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => new KhachHangDto(
                reader.GetString("ma_kh"),
                reader.GetString("tenkhachhang"),
                reader.GetNullableString("sodienthoai"),
                reader.GetNullableString("diachi"),
                reader.GetNullableString("gioitinh")));
    }

    public async Task CreateKhachHangAsync(UpsertKhachHangRequest request)
    {
        EnsureRequired(request.MaKh, nameof(request.MaKh));
        EnsureRequired(request.TenKhachHang, nameof(request.TenKhachHang));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            INSERT INTO K_H (ma_kh, tenkhachhang, sodienthoai, diachi, gioitinh)
            VALUES (@ma_kh, @tenkhachhang, @sodienthoai, @diachi, @gioitinh)
            """;

        await SqlHelpers.ExecuteAsync(connection, sql, cmd => BindKhachHang(cmd, request, request.MaKh));
    }

    public async Task<bool> UpdateKhachHangAsync(string id, UpsertKhachHangRequest request)
    {
        EnsureRequired(request.TenKhachHang, nameof(request.TenKhachHang));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            UPDATE K_H
            SET tenkhachhang = @tenkhachhang,
                sodienthoai = @sodienthoai,
                diachi = @diachi,
                gioitinh = @gioitinh
            WHERE ma_kh = @ma_kh AND trangthai = 1
            """;

        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd => BindKhachHang(cmd, request, id));
        return affected > 0;
    }

    public Task<bool> DeleteKhachHangAsync(string id)
    {
        return DeleteWithChecksAsync(
            "UPDATE K_H SET trangthai = 0 WHERE ma_kh = @id AND trangthai = 1",
            id,
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa khách hàng này vì đã có phiếu gọi đồ uống."),
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa khách hàng này vì đã có hóa đơn bán hàng."));
    }

    public async Task<IReadOnlyList<NhaCungCapDto>> GetNhaCungCapAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT ma_ncc, tennhacungcap, diachincc, sodienthoaincc
            FROM NCC
            WHERE trangthai = 1
              AND (@keyword IS NULL
               OR ma_ncc LIKE @like
               OR tennhacungcap LIKE @like
               OR sodienthoaincc LIKE @like)
            ORDER BY ma_ncc
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => new NhaCungCapDto(
                reader.GetString("ma_ncc"),
                reader.GetString("tennhacungcap"),
                reader.GetNullableString("diachincc"),
                reader.GetNullableString("sodienthoaincc")));
    }

    public async Task CreateNhaCungCapAsync(UpsertNhaCungCapRequest request)
    {
        EnsureRequired(request.MaNcc, nameof(request.MaNcc));
        EnsureRequired(request.TenNhaCungCap, nameof(request.TenNhaCungCap));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            INSERT INTO NCC (ma_ncc, tennhacungcap, diachincc, sodienthoaincc)
            VALUES (@ma_ncc, @tennhacungcap, @diachincc, @sodienthoaincc)
            """;

        await SqlHelpers.ExecuteAsync(connection, sql, cmd => BindNhaCungCap(cmd, request, request.MaNcc));
    }

    public async Task<bool> UpdateNhaCungCapAsync(string id, UpsertNhaCungCapRequest request)
    {
        EnsureRequired(request.TenNhaCungCap, nameof(request.TenNhaCungCap));

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            UPDATE NCC
            SET tennhacungcap = @tennhacungcap,
                diachincc = @diachincc,
                sodienthoaincc = @sodienthoaincc
            WHERE ma_ncc = @ma_ncc AND trangthai = 1
            """;

        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd => BindNhaCungCap(cmd, request, id));
        return affected > 0;
    }

    public Task<bool> DeleteNhaCungCapAsync(string id)
    {
        return DeleteWithChecksAsync(
            "UPDATE NCC SET trangthai = 0 WHERE ma_ncc = @id AND trangthai = 1",
            id,
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa nhà cung cấp này vì đã có phiếu nhập hàng."),
            new ReferenceCheck(
                "SELECT 0",
                "Không thể xóa nhà cung cấp này vì đã có phiếu kiểm kê."));
    }

    public async Task<IReadOnlyList<NguoiDungDto>> GetNguoiDungAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT nd.ma_nd, nd.tennd, nd.sdt, nd.usr, nd.vitri, nd.trangthai,
                   nh.ma_nhom, nh.tennhom
            FROM NGUOIDUNG nd
            LEFT JOIN ND_NHOM ndn ON ndn.ma_nd = nd.ma_nd
            LEFT JOIN NHOMND nh ON nh.ma_nhom = ndn.ma_nhom
            WHERE @keyword IS NULL
               OR nd.ma_nd LIKE @like
               OR nd.tennd LIKE @like
               OR nd.usr LIKE @like
               OR nh.tennhom LIKE @like
            ORDER BY nd.ma_nd
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => new NguoiDungDto(
                reader.GetString("ma_nd"),
                reader.GetString("tennd"),
                reader.GetNullableString("sdt"),
                reader.GetString("usr"),
                reader.GetNullableString("vitri"),
                Convert.ToBoolean(reader["trangthai"]),
                reader.GetNullableString("ma_nhom"),
                reader.GetNullableString("tennhom")));
    }

    public async Task<IReadOnlyList<NhomNguoiDungDto>> GetNhomNguoiDungAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT ma_nhom, tennhom, mota, trangthai
            FROM NHOMND
            WHERE @keyword IS NULL
               OR ma_nhom LIKE @like
               OR tennhom LIKE @like
            ORDER BY ma_nhom
            """;

        return await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => new NhomNguoiDungDto(
                reader.GetString("ma_nhom"),
                reader.GetString("tennhom"),
                reader.GetNullableString("mota"),
                Convert.ToBoolean(reader["trangthai"])));
    }

    public async Task CreateNguoiDungAsync(UpsertNguoiDungRequest request)
    {
        EnsureRequired(request.MaNd, nameof(request.MaNd));
        EnsureRequired(request.TenNd, nameof(request.TenNd));
        EnsureRequired(request.UserName, nameof(request.UserName));
        EnsureRequired(request.Password, nameof(request.Password));

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (Microsoft.Data.SqlClient.SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            const string userSql = """
                INSERT INTO NGUOIDUNG (ma_nd, tennd, sdt, usr, pwd_hash, vitri, trangthai)
                VALUES (@ma_nd, @tennd, @sdt, @usr, @pwd_hash, @vitri, @trangthai)
                """;

            await SqlHelpers.ExecuteAsync(connection, userSql, cmd => BindNguoiDung(cmd, request, request.MaNd, requirePassword: true), transaction);
            await SaveNguoiDungNhomAsync(connection, transaction, request.MaNd, request.MaNhom);
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> UpdateNguoiDungAsync(string id, UpsertNguoiDungRequest request)
    {
        EnsureRequired(request.TenNd, nameof(request.TenNd));
        EnsureRequired(request.UserName, nameof(request.UserName));

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (Microsoft.Data.SqlClient.SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            const string userSql = """
                UPDATE NGUOIDUNG
                SET tennd = @tennd,
                    sdt = @sdt,
                    usr = @usr,
                    pwd_hash = CASE WHEN @pwd_hash IS NULL THEN pwd_hash ELSE @pwd_hash END,
                    vitri = @vitri,
                    trangthai = @trangthai
                WHERE ma_nd = @ma_nd
                """;

            var affected = await SqlHelpers.ExecuteAsync(connection, userSql, cmd => BindNguoiDung(cmd, request, id, requirePassword: false), transaction);
            if (affected == 0)
            {
                await transaction.RollbackAsync();
                return false;
            }

            await SaveNguoiDungNhomAsync(connection, transaction, id, request.MaNhom);
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> DeleteNguoiDungAsync(string id)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = "UPDATE NGUOIDUNG SET trangthai = 0 WHERE ma_nd = @id";
        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd => cmd.AddParam("@id", id));
        return affected > 0;
    }

    private static DoUongDto MapDoUong(Microsoft.Data.SqlClient.SqlDataReader reader)
    {
        return new DoUongDto(
            reader.GetString("ma_du"),
            reader.GetString("ma_ldu"),
            reader.GetString("tenloaidouong"),
            reader.GetString("tendouong"),
            reader.GetDecimal("dongia"));
    }

    private static void BindKhachHang(Microsoft.Data.SqlClient.SqlCommand cmd, UpsertKhachHangRequest request, string id)
    {
        cmd.AddParam("@ma_kh", id);
        cmd.AddParam("@tenkhachhang", request.TenKhachHang);
        cmd.AddParam("@sodienthoai", request.SoDienThoai);
        cmd.AddParam("@diachi", request.DiaChi);
        cmd.AddParam("@gioitinh", request.GioiTinh);
    }

    private static void BindNhaCungCap(Microsoft.Data.SqlClient.SqlCommand cmd, UpsertNhaCungCapRequest request, string id)
    {
        cmd.AddParam("@ma_ncc", id);
        cmd.AddParam("@tennhacungcap", request.TenNhaCungCap);
        cmd.AddParam("@diachincc", request.DiaChiNcc);
        cmd.AddParam("@sodienthoaincc", request.SoDienThoaiNcc);
    }

    private static void BindNguoiDung(
        Microsoft.Data.SqlClient.SqlCommand cmd,
        UpsertNguoiDungRequest request,
        string id,
        bool requirePassword)
    {
        var password = string.IsNullOrWhiteSpace(request.Password) ? null : request.Password.Trim();
        if (requirePassword)
        {
            EnsureRequired(password, nameof(request.Password));
        }

        cmd.AddParam("@ma_nd", id);
        cmd.AddParam("@tennd", request.TenNd);
        cmd.AddParam("@sdt", request.Sdt);
        cmd.AddParam("@usr", request.UserName);
        cmd.AddParam("@pwd_hash", password is null ? null : PasswordHasher.Hash(password));
        cmd.AddParam("@vitri", request.ViTri);
        cmd.AddParam("@trangthai", request.TrangThai);
    }

    private static async Task SaveNguoiDungNhomAsync(
        Microsoft.Data.SqlClient.SqlConnection connection,
        Microsoft.Data.SqlClient.SqlTransaction transaction,
        string maNd,
        string? maNhom)
    {
        await SqlHelpers.ExecuteAsync(
            connection,
            "DELETE FROM ND_NHOM WHERE ma_nd = @ma_nd",
            cmd => cmd.AddParam("@ma_nd", maNd),
            transaction);

        if (string.IsNullOrWhiteSpace(maNhom))
        {
            return;
        }

        await SqlHelpers.ExecuteAsync(
            connection,
            "INSERT INTO ND_NHOM (ma_nd, ma_nhom) VALUES (@ma_nd, @ma_nhom)",
            cmd =>
            {
                cmd.AddParam("@ma_nd", maNd);
                cmd.AddParam("@ma_nhom", maNhom);
            },
            transaction);
    }

    private async Task<bool> DeleteWithChecksAsync(string sql, string id, params ReferenceCheck[] checks)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        foreach (var check in checks)
        {
            var count = await SqlHelpers.ScalarAsync<int>(
                connection,
                check.Sql,
                cmd => cmd.AddParam("@id", id));

            if (count > 0)
            {
                throw new ArgumentException(check.Message);
            }
        }

        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd => cmd.AddParam("@id", id));
        return affected > 0;
    }

    private sealed record ReferenceCheck(string Sql, string Message);

    private static void BindKeyword(Microsoft.Data.SqlClient.SqlCommand cmd, string? keyword)
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

    private static void EnsurePositive(decimal value, string name)
    {
        if (value < 0)
        {
            throw new ArgumentException($"{name} must be greater than or equal to 0.");
        }
    }
}
