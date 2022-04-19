using Microsoft.IdentityModel.Tokens;

namespace Core.Authentication.Jwt;

public class JwtSecurityTokenDescriptor : SecurityTokenDescriptor
{
    public DateTime? RefreshTokenExpires { get; init; }
}