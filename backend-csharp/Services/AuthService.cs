using backend_csharp.Data;
using backend_csharp.Models;
using backend_csharp.Security;
using Microsoft.Data.SqlClient;

namespace backend_csharp.Services;

public sealed class AuthService
{
    private readonly DbConnectionFactory _db;
    private readonly JwtTokenService _jwt;

    public AuthService(DbConnectionFactory db, JwtTokenService jwt)
    {
        _db = db;
        _jwt = jwt;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var username = request.Username?.Trim();
        var password = request.Password?.Trim();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return null;
        }

        await using var connection = _db.Create();
        await connection.OpenAsync();

        const string userSql = """
            SELECT ma_nd, tennd, usr, pwd_hash, vitri
            FROM NGUOIDUNG
            WHERE usr = @usr AND trangthai = 1
            """;

        var users = await SqlHelpers.QueryAsync(
            connection,
            userSql,
            cmd =>
            {
                cmd.AddParam("@usr", username);
            },
            reader => new
            {
                MaNd = reader.GetString("ma_nd"),
                TenNd = reader.GetString("tennd"),
                UserName = reader.GetString("usr"),
                PasswordHash = reader.GetString("pwd_hash"),
                ViTri = reader.GetNullableString("vitri")
            });

        var user = users.FirstOrDefault();
        if (user is null || !PasswordHasher.Verify(password, user.PasswordHash))
        {
            return null;
        }

        if (PasswordHasher.NeedsRehash(user.PasswordHash))
        {
            await SqlHelpers.ExecuteAsync(
                connection,
                "UPDATE NGUOIDUNG SET pwd_hash = @pwd_hash WHERE ma_nd = @ma_nd",
                cmd =>
                {
                    cmd.AddParam("@pwd_hash", PasswordHasher.Hash(password));
                    cmd.AddParam("@ma_nd", user.MaNd);
                });
        }

        const string roleSql = """
            SELECT n.ma_nhom, n.tennhom
            FROM ND_NHOM nn
            INNER JOIN NHOMND n ON n.ma_nhom = nn.ma_nhom
            WHERE nn.ma_nd = @ma_nd
            ORDER BY n.ma_nhom
            """;

        var roles = await SqlHelpers.QueryAsync(
            connection,
            roleSql,
            cmd => cmd.AddParam("@ma_nd", user.MaNd),
            reader => new AuthCodeName(
                reader.GetString("ma_nhom"),
                reader.GetString("tennhom")));

        const string permissionSql = """
            SELECT DISTINCT q.ma_quyen, q.tenquyen
            FROM ND_NHOM nn
            INNER JOIN PHANQUYEN pq ON pq.ma_nhom = nn.ma_nhom
            INNER JOIN QUYEN q ON q.ma_quyen = pq.ma_quyen
            WHERE nn.ma_nd = @ma_nd
            ORDER BY q.tenquyen
            """;

        var permissions = await SqlHelpers.QueryAsync(
            connection,
            permissionSql,
            cmd => cmd.AddParam("@ma_nd", user.MaNd),
            reader => new AuthCodeName(
                reader.GetString("ma_quyen"),
                reader.GetString("tenquyen")));

        const string managerSql = """
            SELECT TOP 1 nd.tennd
            FROM NGUOIDUNG nd
            INNER JOIN ND_NHOM nn ON nn.ma_nd = nd.ma_nd
            WHERE nn.ma_nhom = 'N04' AND nd.trangthai = 1
            ORDER BY nd.ma_nd
            """;

        var managers = await SqlHelpers.QueryAsync(
            connection,
            managerSql,
            null,
            reader => reader.GetString("tennd"));

        var authenticatedUser = new AuthenticatedUser(
            user.MaNd,
            user.TenNd,
            user.UserName,
            user.ViTri,
            roles,
            permissions);
        var token = _jwt.CreateToken(authenticatedUser);

        return new LoginResponse(
            token.Token,
            token.ExpiresAt,
            user.MaNd,
            user.TenNd,
            user.UserName,
            user.ViTri,
            managers.FirstOrDefault(),
            roles.Select(x => x.Ten).ToList(),
            permissions.Select(x => x.Ten).ToList(),
            roles.Select(x => x.Ma).ToList(),
            permissions.Select(x => x.Ma).ToList());
    }
}
