namespace backend_csharp.Security;

public sealed class JwtOptions
{
    public string Issuer { get; set; } = "QLBH_TAKEAWAY";
    public string Audience { get; set; } = "QLBH_TAKEAWAY_FRONTEND";
    public string Secret { get; set; } = string.Empty;
    public int ExpireMinutes { get; set; } = 120;
}
