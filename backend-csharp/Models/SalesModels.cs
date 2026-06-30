namespace backend_csharp.Models;
//Trả dữ liệu về gồm thông tin phiếu và danh sách chi tiết
public sealed record PhieuGoiDoUongDto(
    string SoPgdu,
    string MaKh,
    string TenKhachHang,
    DateOnly NgayGoiDoUong,
    TimeOnly ThoiGianGoiDoUong,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<ChiTietPhieuGoiDto> ChiTiet);
// Từng dòng chi tiết của phiếu gọi
public sealed record ChiTietPhieuGoiDto(
    string MaDu,
    string TenDoUong,
    string Size,
    int SoLuongGoi,
    string? YeuCauDacBiet,
    decimal DonGia,
    decimal ThanhTien);
// Request tạo/ sửa phiếu
public sealed record CreatePhieuGoiRequest(
    string SoPgdu,
    string MaKh,
    DateOnly NgayGoiDoUong,
    TimeOnly ThoiGianGoiDoUong,
    string? TenKhachHang,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<CreateChiTietPhieuGoiRequest> ChiTiet);
//Chi tiết gửi lên khi tạo phiếu
public sealed record CreateChiTietPhieuGoiRequest(
    string MaDu,
    string Size,
    int SoLuongGoi,
    string? YeuCauDacBiet);
// Hóa đơn trả về
public sealed record HoaDonDto(
    string SoHdbdu,
    string MaKhachHang,
    string TenKhachHang,
    string SoPgdu,
    DateOnly NgayLapHoaDon,
    TimeOnly ThoiGianThanhToan,
    string HinhThucThanhToan,
    string TrangThai,
    string? GhiChu,
    string NguoiLapHoaDon,
    string TenNhanVien,
    string MaNd,
    decimal TongTien,
    IReadOnlyList<ChiTietHoaDonDto> ChiTiet);
// Chi tiết hóa đơn trả về
public sealed record ChiTietHoaDonDto(
    string MaDu,
    string TenDoUong,
    string Size,
    int SoLuongBan,
    decimal DonGia,
    decimal ThanhTien);
// Request tạo hóa đơn
public sealed record CreateHoaDonRequest(
    string SoHdbdu,
    string MaKhachHang,
    string SoPgdu,
    DateOnly NgayLapHoaDon,
    TimeOnly ThoiGianThanhToan,
    string HinhThucThanhToan,
    string TrangThai,
    string? GhiChu,
    string NguoiLapHoaDon,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<CreateChiTietHoaDonRequest>? ChiTiet);
//Chi tiết đồ uống bán
public sealed record CreateChiTietHoaDonRequest(
    string MaDu,
    string Size,
    int SoLuongBan);
