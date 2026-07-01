using backend_csharp.Data;
using backend_csharp.Models;
using Microsoft.Data.SqlClient;

namespace backend_csharp.Services;

public sealed class InventoryService
{
    private static readonly HashSet<string> TrangThaiDonHopLe = new(StringComparer.OrdinalIgnoreCase)
    {
        "MoiLap",
        "DaGuiNCC",
        "DaNhapHang",
        "DaHuy"
    };

    private readonly DbConnectionFactory _db;

    public InventoryService(DbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<DonNguyenLieuMuaDto>> GetDonNguyenLieuMuaAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT so_dnlm
            FROM D_NLM
            WHERE @keyword IS NULL
               OR so_dnlm LIKE @like
               OR nhacungcap LIKE @like
               OR nguoilapdon LIKE @like
               OR trangthai LIKE @like
            ORDER BY ngaylapdon DESC, so_dnlm DESC
            """;

        var ids = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => reader.GetString("so_dnlm"));

        var result = new List<DonNguyenLieuMuaDto>();
        foreach (var id in ids)
        {
            var item = await GetDonNguyenLieuMuaByIdAsync(id);
            if (item is not null)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public async Task<DonNguyenLieuMuaDto?> GetDonNguyenLieuMuaByIdAsync(string soDnlm)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string headerSql = """
            SELECT so_dnlm, ngaylapdon, nhacungcap, diachi, sodienthoai,
                   bophan, ghichu, nguoilapdon, quanly, tennd, ma_nd, trangthai
            FROM D_NLM
            WHERE so_dnlm = @so_dnlm
            """;

        var headers = await SqlHelpers.QueryAsync(
            connection,
            headerSql,
            cmd => cmd.AddParam("@so_dnlm", soDnlm),
            reader => new
            {
                SoDnlm = reader.GetString("so_dnlm"),
                NgayLapDon = reader.GetDateOnly("ngaylapdon"),
                NhaCungCap = reader.GetString("nhacungcap"),
                DiaChi = reader.GetNullableString("diachi"),
                SoDienThoai = reader.GetNullableString("sodienthoai"),
                BoPhan = reader.GetString("bophan"),
                GhiChu = reader.GetNullableString("ghichu"),
                NguoiLapDon = reader.GetString("nguoilapdon"),
                QuanLy = reader.GetNullableString("quanly"),
                TenNhanVien = reader.GetString("tennd"),
                MaNd = reader.GetString("ma_nd"),
                TrangThai = reader.GetString("trangthai")
            });

        var header = headers.FirstOrDefault();
        if (header is null)
        {
            return null;
        }

        var details = await GetDonNguyenLieuDetailsAsync(connection, soDnlm);
        return new DonNguyenLieuMuaDto(
            header.SoDnlm,
            header.NgayLapDon,
            header.NhaCungCap,
            header.DiaChi,
            header.SoDienThoai,
            header.BoPhan,
            header.GhiChu,
            header.NguoiLapDon,
            header.QuanLy,
            header.TenNhanVien,
            header.MaNd,
            header.TrangThai,
            details);
    }

    public async Task CreateDonNguyenLieuMuaAsync(CreateDonNguyenLieuMuaRequest request)
    {
        EnsureRequired(request.SoDnlm, nameof(request.SoDnlm));
        EnsureRequired(request.NhaCungCap, nameof(request.NhaCungCap));
        EnsureRequired(request.BoPhan, nameof(request.BoPhan));
        EnsureRequired(request.NguoiLapDon, nameof(request.NguoiLapDon));
        EnsureRequired(request.TenNhanVien, nameof(request.TenNhanVien));
        EnsureRequired(request.MaNd, nameof(request.MaNd));
        EnsureHasDetails(request.ChiTiet.Count, "Purchase request requires at least one ingredient detail.");
        var trangThai = NormalizeTrangThai(string.IsNullOrWhiteSpace(request.TrangThai) ? "MoiLap" : request.TrangThai);

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            const string headerSql = """
                INSERT INTO D_NLM
                    (so_dnlm, ngaylapdon, nhacungcap, diachi, sodienthoai, bophan,
                     ghichu, nguoilapdon, quanly, tennd, ma_nd, trangthai)
                VALUES
                    (@so_dnlm, @ngaylapdon, @nhacungcap, @diachi, @sodienthoai, @bophan,
                     @ghichu, @nguoilapdon, @quanly, @tennd, @ma_nd, @trangthai)
                """;

            await SqlHelpers.ExecuteAsync(connection, headerSql, cmd =>
            {
                cmd.AddParam("@so_dnlm", request.SoDnlm);
                cmd.AddParam("@ngaylapdon", ToDateTime(request.NgayLapDon));
                cmd.AddParam("@nhacungcap", request.NhaCungCap);
                cmd.AddParam("@diachi", request.DiaChi);
                cmd.AddParam("@sodienthoai", request.SoDienThoai);
                cmd.AddParam("@bophan", request.BoPhan);
                cmd.AddParam("@ghichu", request.GhiChu);
                cmd.AddParam("@nguoilapdon", request.NguoiLapDon);
                cmd.AddParam("@quanly", request.QuanLy);
                cmd.AddParam("@tennd", request.TenNhanVien);
                cmd.AddParam("@ma_nd", request.MaNd);
                cmd.AddParam("@trangthai", trangThai);
            }, transaction);

            const string detailSql = """
                INSERT INTO C_T_DNLMUA (ma_nl, so_dnlm, soluongdenghi, dongiadukien)
                VALUES (@ma_nl, @so_dnlm, @soluongdenghi, @dongiadukien)
                """;

            foreach (var detail in request.ChiTiet)
            {
                EnsureRequired(detail.MaNl, nameof(detail.MaNl));
                EnsurePositive(detail.SoLuongDeNghi, nameof(detail.SoLuongDeNghi));

                await SqlHelpers.ExecuteAsync(connection, detailSql, cmd =>
                {
                    cmd.AddParam("@ma_nl", detail.MaNl);
                    cmd.AddParam("@so_dnlm", request.SoDnlm);
                    cmd.AddParam("@soluongdenghi", detail.SoLuongDeNghi);
                    cmd.AddParam("@dongiadukien", detail.DonGiaDuKien);
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

    public async Task<bool> UpdateDonNguyenLieuMuaAsync(string soDnlm, CreateDonNguyenLieuMuaRequest request)
    {
        EnsureRequired(request.NhaCungCap, nameof(request.NhaCungCap));
        EnsureRequired(request.BoPhan, nameof(request.BoPhan));
        EnsureRequired(request.NguoiLapDon, nameof(request.NguoiLapDon));
        EnsureRequired(request.TenNhanVien, nameof(request.TenNhanVien));
        EnsureRequired(request.MaNd, nameof(request.MaNd));
        EnsureHasDetails(request.ChiTiet.Count, "Purchase request requires at least one ingredient detail.");

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            var currentTrangThai = await GetDonTrangThaiAsync(connection, transaction, soDnlm);
            if (currentTrangThai is null)
            {
                await transaction.RollbackAsync();
                return false;
            }

            EnsureDonCoTheSua(currentTrangThai);
            var trangThai = NormalizeTrangThai(string.IsNullOrWhiteSpace(request.TrangThai) ? currentTrangThai : request.TrangThai);

            const string updateSql = """
                UPDATE D_NLM
                SET ngaylapdon = @ngaylapdon,
                    nhacungcap = @nhacungcap,
                    diachi = @diachi,
                    sodienthoai = @sodienthoai,
                    bophan = @bophan,
                    ghichu = @ghichu,
                    nguoilapdon = @nguoilapdon,
                    quanly = @quanly,
                    tennd = @tennd,
                    ma_nd = @ma_nd,
                    trangthai = @trangthai
                WHERE so_dnlm = @so_dnlm
                """;

            var affected = await SqlHelpers.ExecuteAsync(connection, updateSql, cmd =>
            {
                cmd.AddParam("@so_dnlm", soDnlm);
                cmd.AddParam("@ngaylapdon", ToDateTime(request.NgayLapDon));
                cmd.AddParam("@nhacungcap", request.NhaCungCap);
                cmd.AddParam("@diachi", request.DiaChi);
                cmd.AddParam("@sodienthoai", request.SoDienThoai);
                cmd.AddParam("@bophan", request.BoPhan);
                cmd.AddParam("@ghichu", request.GhiChu);
                cmd.AddParam("@nguoilapdon", request.NguoiLapDon);
                cmd.AddParam("@quanly", request.QuanLy);
                cmd.AddParam("@tennd", request.TenNhanVien);
                cmd.AddParam("@ma_nd", request.MaNd);
                cmd.AddParam("@trangthai", trangThai);
            }, transaction);

            if (affected == 0)
            {
                await transaction.RollbackAsync();
                return false;
            }

            await SqlHelpers.ExecuteAsync(
                connection,
                "DELETE FROM C_T_DNLMUA WHERE so_dnlm = @so_dnlm",
                cmd => cmd.AddParam("@so_dnlm", soDnlm),
                transaction);

            const string detailSql = """
                INSERT INTO C_T_DNLMUA (ma_nl, so_dnlm, soluongdenghi, dongiadukien)
                VALUES (@ma_nl, @so_dnlm, @soluongdenghi, @dongiadukien)
                """;

            foreach (var detail in request.ChiTiet)
            {
                EnsureRequired(detail.MaNl, nameof(detail.MaNl));
                EnsurePositive(detail.SoLuongDeNghi, nameof(detail.SoLuongDeNghi));

                await SqlHelpers.ExecuteAsync(connection, detailSql, cmd =>
                {
                    cmd.AddParam("@ma_nl", detail.MaNl);
                    cmd.AddParam("@so_dnlm", soDnlm);
                    cmd.AddParam("@soluongdenghi", detail.SoLuongDeNghi);
                    cmd.AddParam("@dongiadukien", detail.DonGiaDuKien);
                }, transaction);
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

    public async Task<bool> DeleteDonNguyenLieuMuaAsync(string soDnlm)
    {
        await EnsureDonNguyenLieuMuaCanDeleteAsync(soDnlm);

        return await DeleteHeaderDetailsAsync(
            "DELETE FROM C_T_DNLMUA WHERE so_dnlm = @id",
            "DELETE FROM D_NLM WHERE so_dnlm = @id",
            soDnlm);
    }

    public async Task<bool> UpdateTrangThaiDonNguyenLieuMuaAsync(string soDnlm, UpdateTrangThaiDonNguyenLieuMuaRequest request)
    {
        var trangThaiMoi = NormalizeTrangThai(request.TrangThai);

        await using var connection = _db.Create();
        await connection.OpenAsync();

        var currentTrangThai = await GetDonTrangThaiAsync(connection, null, soDnlm);
        if (currentTrangThai is null)
        {
            return false;
        }

        var hasReceipt = await HasPhieuNhapHangAsync(connection, null, soDnlm);
        if (hasReceipt && !trangThaiMoi.Equals("DaNhapHang", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Don nay da co phieu nhap hang nen trang thai phai la DaNhapHang.");
        }

        if (currentTrangThai.Equals("DaNhapHang", StringComparison.OrdinalIgnoreCase) &&
            !trangThaiMoi.Equals("DaNhapHang", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Don da nhap hang khong duoc chuyen ve trang thai khac.");
        }

        const string sql = "UPDATE D_NLM SET trangthai = @trangthai WHERE so_dnlm = @so_dnlm";
        var affected = await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
        {
            cmd.AddParam("@so_dnlm", soDnlm);
            cmd.AddParam("@trangthai", trangThaiMoi);
        });

        return affected > 0;
    }

    public async Task<IReadOnlyList<PhieuNhapHangDto>> GetPhieuNhapHangAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT so_pnh
            FROM P_NH
            WHERE @keyword IS NULL
               OR so_pnh LIKE @like
               OR so_dnlm LIKE @like
               OR ma_ncc LIKE @like
               OR nguoigiaohang LIKE @like
            ORDER BY ngaygiao DESC, thoigiangiaohang DESC, so_pnh DESC
            """;

        var ids = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => reader.GetString("so_pnh"));

        var result = new List<PhieuNhapHangDto>();
        foreach (var id in ids)
        {
            var item = await GetPhieuNhapHangByIdAsync(id);
            if (item is not null)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public async Task<PhieuNhapHangDto?> GetPhieuNhapHangByIdAsync(string soPnh)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string headerSql = """
            SELECT p.so_pnh, p.ma_ncc, ncc.tennhacungcap, p.so_dnlm, p.ngaygiao,
                   p.thoigiangiaohang, p.tenkhachhang, p.nguoigiaohang,
                   p.nguoinhanhang, p.ma_nl, p.soluonggiao, p.thanhtien,
                   p.tennd, p.ma_nd
            FROM P_NH p
            INNER JOIN NCC ncc ON ncc.ma_ncc = p.ma_ncc
            WHERE p.so_pnh = @so_pnh
            """;

        var headers = await SqlHelpers.QueryAsync(
            connection,
            headerSql,
            cmd => cmd.AddParam("@so_pnh", soPnh),
            reader => new
            {
                SoPnh = reader.GetString("so_pnh"),
                MaNcc = reader.GetString("ma_ncc"),
                TenNhaCungCap = reader.GetString("tennhacungcap"),
                SoDnlm = reader.GetString("so_dnlm"),
                NgayGiao = reader.GetDateOnly("ngaygiao"),
                GioGiao = reader.GetTimeOnly("thoigiangiaohang"),
                TenKhachHang = reader.GetNullableString("tenkhachhang"),
                NguoiGiaoHang = reader.GetString("nguoigiaohang"),
                NguoiNhanHang = reader.GetString("nguoinhanhang"),
                HeaderMaNl = reader.GetString("ma_nl"),
                HeaderSoLuong = reader.GetInt("soluonggiao"),
                HeaderThanhTien = reader.GetDecimal("thanhtien"),
                TenNhanVien = reader.GetString("tennd"),
                MaNd = reader.GetString("ma_nd")
            });

        var header = headers.FirstOrDefault();
        if (header is null)
        {
            return null;
        }

        var details = await GetPhieuNhapHangDetailsAsync(
            connection,
            soPnh,
            header.HeaderMaNl,
            header.HeaderSoLuong,
            header.HeaderThanhTien);

        return new PhieuNhapHangDto(
            header.SoPnh,
            header.MaNcc,
            header.TenNhaCungCap,
            header.SoDnlm,
            header.NgayGiao,
            header.GioGiao,
            header.TenKhachHang,
            header.NguoiGiaoHang,
            header.NguoiNhanHang,
            header.TenNhanVien,
            header.MaNd,
            details.Sum(x => x.ThanhTien),
            details);
    }

    public async Task CreatePhieuNhapHangAsync(CreatePhieuNhapHangRequest request)
    {
        EnsureRequired(request.SoPnh, nameof(request.SoPnh));
        EnsureRequired(request.MaNcc, nameof(request.MaNcc));
        EnsureRequired(request.SoDnlm, nameof(request.SoDnlm));
        EnsureRequired(request.NguoiGiaoHang, nameof(request.NguoiGiaoHang));
        EnsureRequired(request.NguoiNhanHang, nameof(request.NguoiNhanHang));
        EnsureRequired(request.TenNhanVien, nameof(request.TenNhanVien));
        EnsureRequired(request.MaNd, nameof(request.MaNd));
        EnsureHasDetails(request.ChiTiet.Count, "Receipt requires at least one ingredient detail.");

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            var first = request.ChiTiet[0];
            var firstName = await GetIngredientNameAsync(connection, transaction, first.MaNl);
            var firstAmount = first.SoLuongGiao * first.DonGia;

            const string headerSql = """
                INSERT INTO P_NH
                    (so_pnh, ma_ncc, so_dnlm, ngaygiao, thoigiangiaohang,
                     tenkhachhang, nguoigiaohang, nguoinhanhang,
                     ma_nl, soluonggiao, tennguyenlieu, thanhtien, tennd, ma_nd)
                VALUES
                    (@so_pnh, @ma_ncc, @so_dnlm, @ngaygiao, @thoigiangiaohang,
                     @tenkhachhang, @nguoigiaohang, @nguoinhanhang,
                     @ma_nl, @soluonggiao, @tennguyenlieu, @thanhtien, @tennd, @ma_nd)
                """;

            await SqlHelpers.ExecuteAsync(connection, headerSql, cmd =>
            {
                cmd.AddParam("@so_pnh", request.SoPnh);
                cmd.AddParam("@ma_ncc", request.MaNcc);
                cmd.AddParam("@so_dnlm", request.SoDnlm);
                cmd.AddParam("@ngaygiao", ToDateTime(request.NgayGiao));
                cmd.AddParam("@thoigiangiaohang", request.ThoiGianGiaoHang.ToTimeSpan());
                cmd.AddParam("@tenkhachhang", request.TenKhachHang);
                cmd.AddParam("@nguoigiaohang", request.NguoiGiaoHang);
                cmd.AddParam("@nguoinhanhang", request.NguoiNhanHang);
                cmd.AddParam("@ma_nl", first.MaNl);
                cmd.AddParam("@soluonggiao", first.SoLuongGiao);
                cmd.AddParam("@tennguyenlieu", firstName);
                cmd.AddParam("@thanhtien", firstAmount);
                cmd.AddParam("@tennd", request.TenNhanVien);
                cmd.AddParam("@ma_nd", request.MaNd);
            }, transaction);

            const string detailSql = """
                INSERT INTO C_T_PNH (so_pnh, ma_nl, soluonggiao, tinhtrang, ghichu)
                VALUES (@so_pnh, @ma_nl, @soluonggiao, @tinhtrang, @ghichu)
                """;

            foreach (var detail in request.ChiTiet)
            {
                EnsureRequired(detail.MaNl, nameof(detail.MaNl));
                EnsureRequired(detail.TinhTrang, nameof(detail.TinhTrang));
                EnsurePositive(detail.SoLuongGiao, nameof(detail.SoLuongGiao));

                await SqlHelpers.ExecuteAsync(connection, detailSql, cmd =>
                {
                    cmd.AddParam("@so_pnh", request.SoPnh);
                    cmd.AddParam("@ma_nl", detail.MaNl);
                    cmd.AddParam("@soluonggiao", detail.SoLuongGiao);
                    cmd.AddParam("@tinhtrang", detail.TinhTrang);
                    cmd.AddParam("@ghichu", detail.GhiChu);
                }, transaction);
            }

            await SqlHelpers.ExecuteAsync(
                connection,
                "UPDATE D_NLM SET trangthai = 'DaNhapHang' WHERE so_dnlm = @so_dnlm",
                cmd => cmd.AddParam("@so_dnlm", request.SoDnlm),
                transaction);

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> DeletePhieuNhapHangAsync(string soPnh)
    {
        return await DeleteHeaderDetailsAsync(
            "DELETE FROM C_T_PNH WHERE so_pnh = @id",
            "DELETE FROM P_NH WHERE so_pnh = @id",
            soPnh);
    }

    public async Task<IReadOnlyList<PhieuKiemKeDto>> GetPhieuKiemKeAsync(string? keyword)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT so_pkk
            FROM P_KK
            WHERE @keyword IS NULL
               OR so_pkk LIKE @like
               OR ma_ncc LIKE @like
               OR nguoithuchienkiemke LIKE @like
            ORDER BY ngaykiemke DESC, thoigiankiemke DESC, so_pkk DESC
            """;

        var ids = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => BindKeyword(cmd, keyword),
            reader => reader.GetString("so_pkk"));

        var result = new List<PhieuKiemKeDto>();
        foreach (var id in ids)
        {
            var item = await GetPhieuKiemKeByIdAsync(id);
            if (item is not null)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public async Task<PhieuKiemKeDto?> GetPhieuKiemKeByIdAsync(string soPkk)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string headerSql = """
            SELECT so_pkk, ma_ncc, ngaykiemke, thoigiankiemke,
                   nguoithuchienkiemke, nguoigiamsat, tennd, ma_nd
            FROM P_KK
            WHERE so_pkk = @so_pkk
            """;

        var headers = await SqlHelpers.QueryAsync(
            connection,
            headerSql,
            cmd => cmd.AddParam("@so_pkk", soPkk),
            reader => new
            {
                SoPkk = reader.GetString("so_pkk"),
                MaNcc = reader.GetString("ma_ncc"),
                Ngay = reader.GetDateOnly("ngaykiemke"),
                Gio = reader.GetTimeOnly("thoigiankiemke"),
                NguoiKiemKe = reader.GetString("nguoithuchienkiemke"),
                NguoiGiamSat = reader.GetNullableString("nguoigiamsat"),
                TenNhanVien = reader.GetString("tennd"),
                MaNd = reader.GetString("ma_nd")
            });

        var header = headers.FirstOrDefault();
        if (header is null)
        {
            return null;
        }

        var details = await GetPhieuKiemKeDetailsAsync(connection, soPkk);
        return new PhieuKiemKeDto(
            header.SoPkk,
            header.MaNcc,
            header.Ngay,
            header.Gio,
            header.NguoiKiemKe,
            header.NguoiGiamSat,
            header.TenNhanVien,
            header.MaNd,
            details);
    }

    public async Task CreatePhieuKiemKeAsync(CreatePhieuKiemKeRequest request)
    {
        EnsureRequired(request.SoPkk, nameof(request.SoPkk));
        EnsureRequired(request.MaNcc, nameof(request.MaNcc));
        EnsureRequired(request.NguoiThucHienKiemKe, nameof(request.NguoiThucHienKiemKe));
        EnsureRequired(request.TenNhanVien, nameof(request.TenNhanVien));
        EnsureRequired(request.MaNd, nameof(request.MaNd));
        EnsureHasDetails(request.ChiTiet.Count, "Inventory check requires at least one ingredient detail.");

        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            const string headerSql = """
                INSERT INTO P_KK
                    (so_pkk, ma_ncc, ngaykiemke, thoigiankiemke,
                     nguoithuchienkiemke, nguoigiamsat, tennd, ma_nd)
                VALUES
                    (@so_pkk, @ma_ncc, @ngaykiemke, @thoigiankiemke,
                     @nguoithuchienkiemke, @nguoigiamsat, @tennd, @ma_nd)
                """;

            await SqlHelpers.ExecuteAsync(connection, headerSql, cmd =>
            {
                cmd.AddParam("@so_pkk", request.SoPkk);
                cmd.AddParam("@ma_ncc", request.MaNcc);
                cmd.AddParam("@ngaykiemke", ToDateTime(request.NgayKiemKe));
                cmd.AddParam("@thoigiankiemke", request.ThoiGianKiemKe.ToTimeSpan());
                cmd.AddParam("@nguoithuchienkiemke", request.NguoiThucHienKiemKe);
                cmd.AddParam("@nguoigiamsat", request.NguoiGiamSat);
                cmd.AddParam("@tennd", request.TenNhanVien);
                cmd.AddParam("@ma_nd", request.MaNd);
            }, transaction);

            const string detailSql = """
                INSERT INTO C_T_PKK
                    (so_pkk, ma_nl, soluongtheokiemke, soluongthucte, chenhlech,
                     hansudung, tinhtrangchatluong, ghichu)
                VALUES
                    (@so_pkk, @ma_nl, @soluongtheokiemke, @soluongthucte, @chenhlech,
                     @hansudung, @tinhtrangchatluong, @ghichu)
                """;

            foreach (var detail in request.ChiTiet)
            {
                EnsureRequired(detail.MaNl, nameof(detail.MaNl));
                var chenhlech = detail.SoLuongThucTe - detail.SoLuongTheoKiemKe;

                await SqlHelpers.ExecuteAsync(connection, detailSql, cmd =>
                {
                    cmd.AddParam("@so_pkk", request.SoPkk);
                    cmd.AddParam("@ma_nl", detail.MaNl);
                    cmd.AddParam("@soluongtheokiemke", detail.SoLuongTheoKiemKe);
                    cmd.AddParam("@soluongthucte", detail.SoLuongThucTe);
                    cmd.AddParam("@chenhlech", chenhlech);
                    cmd.AddParam("@hansudung", detail.HanSuDung.HasValue ? ToDateTime(detail.HanSuDung.Value) : null);
                    cmd.AddParam("@tinhtrangchatluong", detail.TinhTrangChatLuong);
                    cmd.AddParam("@ghichu", detail.GhiChu);
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

    public async Task<bool> DeletePhieuKiemKeAsync(string soPkk)
    {
        return await DeleteHeaderDetailsAsync(
            "DELETE FROM C_T_PKK WHERE so_pkk = @id",
            "DELETE FROM P_KK WHERE so_pkk = @id",
            soPkk);
    }

    private static async Task<IReadOnlyList<ChiTietDonNguyenLieuMuaDto>> GetDonNguyenLieuDetailsAsync(SqlConnection connection, string soDnlm)
    {
        const string sql = """
            SELECT ct.ma_nl, nl.tennguyenlieu, nl.donvitinh, ct.soluongdenghi, ct.dongiadukien,
                   ct.soluongdenghi * ct.dongiadukien AS thanhtiendukien
            FROM C_T_DNLMUA ct
            INNER JOIN NL nl ON nl.ma_nl = ct.ma_nl
            WHERE ct.so_dnlm = @so_dnlm
            ORDER BY ct.ma_nl
            """;

        return await SqlHelpers.QueryAsync(connection, sql, cmd => cmd.AddParam("@so_dnlm", soDnlm), reader =>
            new ChiTietDonNguyenLieuMuaDto(
                reader.GetString("ma_nl"),
                reader.GetString("tennguyenlieu"),
                reader.GetString("donvitinh"),
                reader.GetInt("soluongdenghi"),
                reader.GetDecimal("dongiadukien"),
                reader.GetDecimal("thanhtiendukien")));
    }

    private static async Task<IReadOnlyList<ChiTietPhieuNhapHangDto>> GetPhieuNhapHangDetailsAsync(
        SqlConnection connection,
        string soPnh,
        string headerMaNl,
        int headerSoLuong,
        decimal headerThanhTien)
    {
        const string sql = """
            SELECT ct.ma_nl, nl.tennguyenlieu, ct.soluonggiao, ct.tinhtrang, ct.ghichu
            FROM C_T_PNH ct
            INNER JOIN NL nl ON nl.ma_nl = ct.ma_nl
            WHERE ct.so_pnh = @so_pnh
            ORDER BY ct.ma_nl
            """;

        return await SqlHelpers.QueryAsync(connection, sql, cmd => cmd.AddParam("@so_pnh", soPnh), reader =>
        {
            var maNl = reader.GetString("ma_nl");
            var soLuong = reader.GetInt("soluonggiao");
            var donGia = maNl == headerMaNl && headerSoLuong > 0 ? headerThanhTien / headerSoLuong : 0;
            return new ChiTietPhieuNhapHangDto(
                maNl,
                reader.GetString("tennguyenlieu"),
                soLuong,
                reader.GetString("tinhtrang"),
                reader.GetNullableString("ghichu"),
                donGia,
                donGia * soLuong);
        });
    }

    private static async Task<IReadOnlyList<ChiTietPhieuKiemKeDto>> GetPhieuKiemKeDetailsAsync(SqlConnection connection, string soPkk)
    {
        const string sql = """
            SELECT ct.ma_nl, nl.tennguyenlieu, ct.soluongtheokiemke, ct.soluongthucte,
                   ct.chenhlech, ct.hansudung, ct.tinhtrangchatluong, ct.ghichu
            FROM C_T_PKK ct
            INNER JOIN NL nl ON nl.ma_nl = ct.ma_nl
            WHERE ct.so_pkk = @so_pkk
            ORDER BY ct.ma_nl
            """;

        return await SqlHelpers.QueryAsync(connection, sql, cmd => cmd.AddParam("@so_pkk", soPkk), reader =>
        {
            DateOnly? hanSuDung = reader["hansudung"] == DBNull.Value
                ? null
                : DateOnly.FromDateTime(Convert.ToDateTime(reader["hansudung"]));

            return new ChiTietPhieuKiemKeDto(
                reader.GetString("ma_nl"),
                reader.GetString("tennguyenlieu"),
                reader.GetInt("soluongtheokiemke"),
                reader.GetInt("soluongthucte"),
                reader.GetInt("chenhlech"),
                hanSuDung,
                reader.GetNullableString("tinhtrangchatluong"),
                reader.GetNullableString("ghichu"));
        });
    }

    private static async Task<string> GetIngredientNameAsync(SqlConnection connection, SqlTransaction transaction, string maNl)
    {
        const string sql = "SELECT tennguyenlieu FROM NL WHERE ma_nl = @ma_nl";
        var rows = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => cmd.AddParam("@ma_nl", maNl),
            reader => reader.GetString("tennguyenlieu"),
            transaction);

        return rows.FirstOrDefault() ?? throw new ArgumentException($"Ingredient {maNl} does not exist.");
    }

    private async Task<bool> DeleteHeaderDetailsAsync(string deleteDetailSql, string deleteHeaderSql, string id)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            await SqlHelpers.ExecuteAsync(connection, deleteDetailSql, cmd => cmd.AddParam("@id", id), transaction);
            var affected = await SqlHelpers.ExecuteAsync(connection, deleteHeaderSql, cmd => cmd.AddParam("@id", id), transaction);
            await transaction.CommitAsync();
            return affected > 0;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task EnsureDonNguyenLieuMuaCanDeleteAsync(string soDnlm)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        var trangThai = await GetDonTrangThaiAsync(connection, null, soDnlm);
        if (trangThai is null)
        {
            return;
        }

        if (trangThai.Equals("DaNhapHang", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Don da nhap hang khong duoc xoa.");
        }

        const string sql = "SELECT COUNT(1) FROM P_NH WHERE so_dnlm = @id";
        var count = await SqlHelpers.ScalarAsync<int>(
            connection,
            sql,
            cmd => cmd.AddParam("@id", soDnlm));

        if (count > 0)
        {
            throw new ArgumentException("Không thể xóa đơn nguyên liệu mua này vì đã có phiếu nhập hàng liên quan.");
        }
    }

    private static async Task<string?> GetDonTrangThaiAsync(SqlConnection connection, SqlTransaction? transaction, string soDnlm)
    {
        return await SqlHelpers.ScalarAsync<string>(
            connection,
            "SELECT trangthai FROM D_NLM WHERE so_dnlm = @so_dnlm",
            cmd => cmd.AddParam("@so_dnlm", soDnlm),
            transaction);
    }

    private static async Task<bool> HasPhieuNhapHangAsync(SqlConnection connection, SqlTransaction? transaction, string soDnlm)
    {
        var count = await SqlHelpers.ScalarAsync<int>(
            connection,
            "SELECT COUNT(1) FROM P_NH WHERE so_dnlm = @so_dnlm",
            cmd => cmd.AddParam("@so_dnlm", soDnlm),
            transaction);

        return count > 0;
    }

    private static string NormalizeTrangThai(string? trangThai)
    {
        var normalized = string.IsNullOrWhiteSpace(trangThai) ? "MoiLap" : trangThai.Trim();
        if (!TrangThaiDonHopLe.Contains(normalized))
        {
            throw new ArgumentException("Trang thai don nguyen lieu mua khong hop le.");
        }

        return TrangThaiDonHopLe.First(x => x.Equals(normalized, StringComparison.OrdinalIgnoreCase));
    }

    private static void EnsureDonCoTheSua(string trangThai)
    {
        if (trangThai.Equals("DaNhapHang", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Don da nhap hang khong duoc sua.");
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

    private static void EnsureHasDetails(int count, string message)
    {
        if (count == 0)
        {
            throw new ArgumentException(message);
        }
    }
}
