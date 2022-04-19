using Microsoft.IdentityModel.Tokens;

namespace Service.Jwt;

public class JwtSecurityTokenDescriptor : SecurityTokenDescriptor
{
    public DateTime? RefreshTokenExpires { get; init; }
}