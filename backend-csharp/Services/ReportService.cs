using backend_csharp.Data;
using backend_csharp.Models;

namespace backend_csharp.Services;

public sealed class ReportService
{
    private readonly DbConnectionFactory _db;

    public ReportService(DbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<DoanhThuNgayReport> GetDoanhThuNgayAsync(DateOnly ngay)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT hd.so_hdbdu, hd.thoigianthanhtoan, hd.hinhthucthanhtoan,
                   hd.nguoilaphoadon, hd.ghichu,
                   ct.ma_du, du.tendouong, N'Ly' AS donvitinh, ct.size, ct.soluongban,
                   du.dongia, ct.thanhtien
            FROM HD_BDUONG hd
            INNER JOIN C_T_HDBDU ct ON ct.so_hdbdu = hd.so_hdbdu
            INNER JOIN DU du ON du.ma_du = ct.ma_du
            WHERE hd.ngaylaphoadon = @ngay
            ORDER BY hd.thoigianthanhtoan, hd.so_hdbdu, ct.ma_du
            """;

        var items = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd => cmd.AddParam("@ngay", ngay.ToDateTime(TimeOnly.MinValue)),
            reader => new DoanhThuNgayItem(
                reader.GetString("so_hdbdu"),
                reader.GetTimeOnly("thoigianthanhtoan"),
                reader.GetString("hinhthucthanhtoan"),
                reader.GetString("ma_du"),
                reader.GetString("tendouong"),
                reader.GetString("donvitinh"),
                reader.GetString("size"),
                reader.GetInt("soluongban"),
                reader.GetDecimal("dongia"),
                reader.GetDecimal("thanhtien"),
                reader.GetNullableString("ghichu")));

        return new DoanhThuNgayReport(
            ngay,
            items.Count > 0 ? await GetReportCreatorAsync(ngay) : null,
            items.Select(x => x.SoHoaDon).Distinct().Count(),
            items.Sum(x => x.SoLuongBan),
            items.Sum(x => x.ThanhTien),
            items);
    }

    public async Task<DoUongBanChayReport> GetDoUongBanChayAsync(int thang, int nam)
    {
        if (thang is < 1 or > 12)
        {
            throw new ArgumentException("Month must be between 1 and 12.");
        }

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT ct.ma_du, du.tendouong, N'Ly' AS donvitinh,
                   SUM(ct.soluongban) AS tongsoluongban,
                   SUM(ct.thanhtien) AS tongdoanhthu
            FROM HD_BDUONG hd
            INNER JOIN C_T_HDBDU ct ON ct.so_hdbdu = hd.so_hdbdu
            INNER JOIN DU du ON du.ma_du = ct.ma_du
            WHERE MONTH(hd.ngaylaphoadon) = @thang
              AND YEAR(hd.ngaylaphoadon) = @nam
            GROUP BY ct.ma_du, du.tendouong
            ORDER BY SUM(ct.soluongban) DESC, SUM(ct.thanhtien) DESC
            """;

        var items = await SqlHelpers.QueryAsync(
            connection,
            sql,
            cmd =>
            {
                cmd.AddParam("@thang", thang);
                cmd.AddParam("@nam", nam);
            },
            reader => new DoUongBanChayItem(
                reader.GetString("ma_du"),
                reader.GetString("tendouong"),
                reader.GetString("donvitinh"),
                reader.GetInt("tongsoluongban"),
                reader.GetDecimal("tongdoanhthu")));

        return new DoUongBanChayReport(
            thang,
            nam,
            items.Sum(x => x.TongSoLuongBan),
            items.Sum(x => x.TongDoanhThu),
            items);
    }

    private async Task<string?> GetReportCreatorAsync(DateOnly ngay)
    {
        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string sql = """
            SELECT TOP 1 nguoilaphoadon
            FROM HD_BDUONG
            WHERE ngaylaphoadon = @ngay
            ORDER BY thoigianthanhtoan, so_hdbdu
            """;

        return await SqlHelpers.ScalarAsync<string>(
            connection,
            sql,
            cmd => cmd.AddParam("@ngay", ngay.ToDateTime(TimeOnly.MinValue)));
    }
}
