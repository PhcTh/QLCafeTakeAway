namespace backend_csharp.Models;
//Frontend gửi username và password
public sealed record LoginRequest(string Username, string Password);
//Backend trả về thông tin người dùng, nhóm và quyền của người dùng
public sealed record LoginResponse(
    string MaNd,
    string TenNd,
    string UserName,
    string? ViTri,
    string? QuanLyMacDinh,
    IReadOnlyList<string> Nhom,
    IReadOnlyList<string> Quyen);
