using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend_csharp.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace backend_csharp.Security;

public sealed class JwtTokenService
{
    private readonly JwtOptions _options;

    public JwtTokenService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public TokenResult CreateToken(AuthenticatedUser user)
    {
        var now = DateTime.UtcNow;
        var expiresAt = now.AddMinutes(Math.Max(1, _options.ExpireMinutes));
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.MaNd),
            new(ClaimTypes.NameIdentifier, user.MaNd),
            new(ClaimTypes.Name, user.UserName),
            new("maNd", user.MaNd),
            new("userName", user.UserName),
            new("tenNd", user.TenNd)
        };

        if (!string.IsNullOrWhiteSpace(user.ViTri))
        {
            claims.Add(new Claim("viTri", user.ViTri));
        }

        foreach (var group in user.Nhom)
        {
            claims.Add(new Claim("ma_nhom", group.Ma));
            claims.Add(new Claim("nhom", group.Ten));
        }

        foreach (var permission in user.Quyen)
        {
            claims.Add(new Claim("ma_quyen", permission.Ma));
            claims.Add(new Claim("quyen", permission.Ten));
        }

        var credentials = new SigningCredentials(CreateSecurityKey(_options.Secret), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: now,
            expires: expiresAt,
            signingCredentials: credentials);

        return new TokenResult(new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }

    public TokenValidationParameters CreateValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _options.Issuer,
            ValidateAudience = true,
            ValidAudience = _options.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = CreateSecurityKey(_options.Secret),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    }

    private static SymmetricSecurityKey CreateSecurityKey(string secret)
    {
        if (string.IsNullOrWhiteSpace(secret) || Encoding.UTF8.GetByteCount(secret) < 32)
        {
            throw new InvalidOperationException("JWT secret phai co it nhat 32 byte.");
        }

        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
    }
}

public sealed record TokenResult(string Token, DateTime ExpiresAt);
