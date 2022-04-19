namespace Service.Jwt;

public class JwtAuthenticationOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Secret { get; set; }
    public double AccessTokenExpiryInSecond { get; set; }
    public double RefreshTokenExpiryInSecond { get; set; }
}