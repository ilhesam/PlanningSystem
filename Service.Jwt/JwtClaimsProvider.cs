using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain;

namespace Service.Jwt;

public interface IJwtClaimsProvider
{
    IEnumerable<Claim> GetClaims(User user);
}

public class JwtClaimsProvider : IJwtClaimsProvider
{
    public IEnumerable<Claim> GetClaims(User user)
    {
        var now = DateTime.Now;
        var jti = Guid.NewGuid().ToString();
        var userId = user.Id.ToString();
        var userName = user.UserName;

        return new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, jti),
            new(JwtRegisteredClaimNames.Iat, now.ToLongDateString()),
            new(JwtRegisteredClaimNames.Sub, userId),
            new(ClaimTypes.NameIdentifier, userId),
            new(ClaimTypes.Name, userName)
        };
    }
}