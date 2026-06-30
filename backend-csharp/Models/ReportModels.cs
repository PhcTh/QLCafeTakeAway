namespace backend_csharp.Models;

public sealed record DoanhThuNgayReport(
    DateOnly Ngay,
    string? NguoiLapBaoCao,
    int TongSoHoaDon,
    int TongSoLuongDoUong,
    decimal TongDoanhThu,
    IReadOnlyList<DoanhThuNgayItem> ChiTiet);

public sealed record DoanhThuNgayItem(
    string SoHoaDon,
    TimeOnly ThoiGianThanhToan,
    string HinhThucThanhToan,
    string MaDu,
    string TenDoUong,
    string DonViTinh,
    string Size,
    int SoLuongBan,
    decimal DonGia,
    decimal ThanhTien,
    string? GhiChu);

public sealed record DoUongBanChayReport(
    int Thang,
    int Nam,
    int TongSoLuongBan,
    decimal TongDoanhThu,
    IReadOnlyList<DoUongBanChayItem> ChiTiet);

public sealed record DoUongBanChayItem(
    string MaDu,
    string TenDoUong,
    string DonViTinh,
    int TongSoLuongBan,
    decimal TongDoanhThu);
