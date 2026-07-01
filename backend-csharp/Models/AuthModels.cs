namespace backend_csharp.Models;
//Frontend gửi username và password
public sealed record LoginRequest(string Username, string Password);
//Backend trả về thông tin người dùng, nhóm và quyền của người dùng
public sealed record LoginResponse(
    string Token,
    DateTime ExpiresAt,
    string MaNd,
    string TenNd,
    string UserName,
    string? ViTri,
    string? QuanLyMacDinh,
    IReadOnlyList<string> Nhom,
    IReadOnlyList<string> Quyen,
    IReadOnlyList<string> MaNhom,
    IReadOnlyList<string> MaQuyen);

public sealed record AuthenticatedUser(
    string MaNd,
    string TenNd,
    string UserName,
    string? ViTri,
    IReadOnlyList<AuthCodeName> Nhom,
    IReadOnlyList<AuthCodeName> Quyen);

public sealed record AuthCodeName(string Ma, string Ten);
