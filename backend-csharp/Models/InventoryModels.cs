namespace backend_csharp.Models;
//Đơn đề nghị mua nguyên liệu
public sealed record DonNguyenLieuMuaDto(
    string SoDnlm,
    DateOnly NgayLapDon,
    string NhaCungCap,
    string? DiaChi,
    string? SoDienThoai,
    string BoPhan,
    string? GhiChu,
    string NguoiLapDon,
    string? QuanLy,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<ChiTietDonNguyenLieuMuaDto> ChiTiet);
// Từng nguyên liệu trong đơn đề nghị mua nguyên liệu
public sealed record ChiTietDonNguyenLieuMuaDto(
    string MaNl,
    string TenNguyenLieu,
    string DonViTinh,
    int SoLuongDeNghi,
    decimal DonGiaDuKien,
    decimal ThanhTienDuKien);

public sealed record CreateDonNguyenLieuMuaRequest(
    string SoDnlm,
    DateOnly NgayLapDon,
    string NhaCungCap,
    string? DiaChi,
    string? SoDienThoai,
    string BoPhan,
    string? GhiChu,
    string NguoiLapDon,
    string? QuanLy,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<CreateChiTietDonNguyenLieuMuaRequest> ChiTiet);
public sealed record CreateChiTietDonNguyenLieuMuaRequest(
    string MaNl,
    int SoLuongDeNghi,
    decimal DonGiaDuKien);
// Phiếu nhập hàng khi nhà cung cấp giao hàng
public sealed record PhieuNhapHangDto(
    string SoPnh,
    string MaNcc,
    string TenNhaCungCap,
    string SoDnlm,
    DateOnly NgayGiao,
    TimeOnly ThoiGianGiaoHang,
    string? TenKhachHang,
    string NguoiGiaoHang,
    string NguoiNhanHang,
    string TenNhanVien,
    string MaNd,
    decimal TongTien,
    IReadOnlyList<ChiTietPhieuNhapHangDto> ChiTiet);
// Chi tiết nguyên liệu nhập
public sealed record ChiTietPhieuNhapHangDto(
    string MaNl,
    string TenNguyenLieu,
    int SoLuongGiao,
    string TinhTrang,
    string? GhiChu,
    decimal DonGia,
    decimal ThanhTien);
// Yêu cầu tạo phiếu nhập hàng
public sealed record CreatePhieuNhapHangRequest(
    string SoPnh,
    string MaNcc,
    string SoDnlm,
    DateOnly NgayGiao,
    TimeOnly ThoiGianGiaoHang,
    string? TenKhachHang,
    string NguoiGiaoHang,
    string NguoiNhanHang,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<CreateChiTietPhieuNhapHangRequest> ChiTiet);
// Yêu cầu tạo chi tiết phiếu nhập hàng
public sealed record CreateChiTietPhieuNhapHangRequest(
    string MaNl,
    int SoLuongGiao,
    decimal DonGia,
    string TinhTrang,
    string? GhiChu);
// Phiếu kiểm kê tồn/ đếm nguyên liệu
public sealed record PhieuKiemKeDto(
    string SoPkk,
    string MaNcc,
    DateOnly NgayKiemKe,
    TimeOnly ThoiGianKiemKe,
    string NguoiThucHienKiemKe,
    string? NguoiGiamSat,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<ChiTietPhieuKiemKeDto> ChiTiet);
// Chi tiết kiểm kê
public sealed record ChiTietPhieuKiemKeDto(
    string MaNl,
    string TenNguyenLieu,
    int SoLuongTheoKiemKe,
    int SoLuongThucTe,
    int ChenhLech,
    DateOnly? HanSuDung,
    string? TinhTrangChatLuong,
    string? GhiChu);

public sealed record CreatePhieuKiemKeRequest(
    string SoPkk,
    string MaNcc,
    DateOnly NgayKiemKe,
    TimeOnly ThoiGianKiemKe,
    string NguoiThucHienKiemKe,
    string? NguoiGiamSat,
    string TenNhanVien,
    string MaNd,
    IReadOnlyList<CreateChiTietPhieuKiemKeRequest> ChiTiet);

public sealed record CreateChiTietPhieuKiemKeRequest(
    string MaNl,
    int SoLuongTheoKiemKe,
    int SoLuongThucTe,
    DateOnly? HanSuDung,
    string? TinhTrangChatLuong,
    string? GhiChu);
