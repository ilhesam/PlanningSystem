using System.IdentityModel.Tokens.Jwt;

namespace RazorPages.Authentication;

public static class JwtHelper
{
    public static JwtSecurityToken Decode(string accessToken)
    {
        var handler = new JwtSecurityTokenHandler();
        return handler.ReadJwtToken(accessToken);
    }

    public static DateTime GetExpirationDateTime(string accessToken)
    {
        var token = Decode(accessToken);
        return token.ValidTo;
    }
}