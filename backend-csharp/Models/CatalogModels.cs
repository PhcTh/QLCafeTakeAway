namespace backend_csharp.Models;
// Dùng để trả dữ liệu từ server về client
public sealed record LoaiDoUongDto(
    string MaLdu,
    string TenLoaiDoUong,
    string? MoTa);
// Dùng để nhận dữ liệu từ client gửi lên server, upsert là insert hoặc update
public sealed record UpsertLoaiDoUongRequest(
    string MaLdu,
    string TenLoaiDoUong,
    string? MoTa);

public sealed record DoUongDto(
    string MaDu,
    string MaLdu,
    string TenLoaiDoUong,
    string TenDoUong,
    decimal DonGia);

public sealed record UpsertDoUongRequest(
    string MaDu,
    string MaLdu,
    string TenDoUong,
    decimal DonGia);

public sealed record NguyenLieuDto(
    string MaNl,
    string TenNguyenLieu,
    string DonViTinh);

public sealed record UpsertNguyenLieuRequest(
    string MaNl,
    string TenNguyenLieu,
    string DonViTinh);

public sealed record KhachHangDto(
    string MaKh,
    string TenKhachHang,
    string? SoDienThoai,
    string? DiaChi,
    string? GioiTinh);

public sealed record UpsertKhachHangRequest(
    string MaKh,
    string TenKhachHang,
    string? SoDienThoai,
    string? DiaChi,
    string? GioiTinh);

public sealed record NhaCungCapDto(
    string MaNcc,
    string TenNhaCungCap,
    string? DiaChiNcc,
    string? SoDienThoaiNcc);

public sealed record UpsertNhaCungCapRequest(
    string MaNcc,
    string TenNhaCungCap,
    string? DiaChiNcc,
    string? SoDienThoaiNcc);

public sealed record NguoiDungDto(
    string MaNd,
    string TenNd,
    string? Sdt,
    string UserName,
    string? ViTri,
    bool TrangThai,
    string? MaNhom,
    string? TenNhom);

public sealed record NhomNguoiDungDto(
    string MaNhom,
    string TenNhom,
    string? MoTa,
    bool TrangThai);

public sealed record UpsertNguoiDungRequest(
    string MaNd,
    string TenNd,
    string? Sdt,
    string UserName,
    string? Password,
    string? ViTri,
    bool TrangThai,
    string? MaNhom);
