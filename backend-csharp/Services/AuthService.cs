using backend_csharp.Data;
using backend_csharp.Models;
using Microsoft.Data.SqlClient;

namespace backend_csharp.Services;

public sealed class AuthService
{
    private readonly DbConnectionFactory _db;

    public AuthService(DbConnectionFactory db)
    {
        _db = db;
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
            SELECT ma_nd, tennd, usr, vitri
            FROM NGUOIDUNG
            WHERE usr = @usr AND pwd_hash = @pwd AND trangthai = 1
            """;

        var users = await SqlHelpers.QueryAsync(
            connection,
            userSql,
            cmd =>
            {
                cmd.AddParam("@usr", username);
                cmd.AddParam("@pwd", password);
            },
            reader => new
            {
                MaNd = reader.GetString("ma_nd"),
                TenNd = reader.GetString("tennd"),
                UserName = reader.GetString("usr"),
                ViTri = reader.GetNullableString("vitri")
            });

        var user = users.FirstOrDefault();
        if (user is null)
        {
            return null;
        }

        const string roleSql = """
            SELECT n.tennhom
            FROM ND_NHOM nn
            INNER JOIN NHOMND n ON n.ma_nhom = nn.ma_nhom
            WHERE nn.ma_nd = @ma_nd
            ORDER BY n.ma_nhom
            """;

        var roles = await SqlHelpers.QueryAsync(
            connection,
            roleSql,
            cmd => cmd.AddParam("@ma_nd", user.MaNd),
            reader => reader.GetString("tennhom"));

        const string permissionSql = """
            SELECT DISTINCT q.tenquyen
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
            reader => reader.GetString("tenquyen"));

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

        return new LoginResponse(
            user.MaNd,
            user.TenNd,
            user.UserName,
            user.ViTri,
            managers.FirstOrDefault(),
            roles,
            permissions);
    }
}
