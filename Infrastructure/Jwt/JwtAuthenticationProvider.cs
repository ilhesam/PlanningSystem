using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Authentication.Jwt;

public class JwtAuthenticationProvider : IAuthenticationProvider
{
    protected readonly JwtAuthenticationOptions Options;
    protected readonly IJwtClaimsProvider Claims;

    protected virtual byte[] Key => Encoding.ASCII.GetBytes(Options.Secret);
    protected virtual SymmetricSecurityKey SecurityKey => new(Key);
    protected virtual string SecurityAlgorithm => SecurityAlgorithms.HmacSha512Signature;
    protected virtual SigningCredentials SigningCredentials => new(SecurityKey, SecurityAlgorithm);

    public JwtAuthenticationProvider(JwtAuthenticationOptions options, IJwtClaimsProvider claims)
    {
        Options = options;
        Claims = claims;
    }

    public virtual AuthenticationCredential IssueCredential(User user)
    {
        var claims = Claims.GetClaims(user);
        var descriptor = GetTokenDescriptor(claims);

        var accessToken = GenerateAccessToken(descriptor);
        var accessTokenExpiresAt = descriptor.Expires.Value;

        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiresAt = descriptor.RefreshTokenExpires.Value;

        return new AuthenticationCredential(accessToken, accessTokenExpiresAt, refreshToken, refreshTokenExpiresAt);
    }

    protected virtual string GenerateRefreshToken() => Guid.NewGuid().ToString();

    protected virtual string GenerateAccessToken(SecurityTokenDescriptor descriptor)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateJwtSecurityToken(descriptor);
        return handler.WriteToken(token);
    }

    protected virtual JwtSecurityTokenDescriptor GetTokenDescriptor(IEnumerable<Claim> claims)
    {
        var issueTime = DateTime.UtcNow;

        return new JwtSecurityTokenDescriptor
        {
            Issuer = Options.Issuer,
            Audience = Options.Audience,
            Subject = new ClaimsIdentity(claims),
            Expires = issueTime.AddSeconds(Options.AccessTokenExpiryInSecond),
            RefreshTokenExpires = issueTime.AddSeconds(Options.RefreshTokenExpiryInSecond),
            SigningCredentials = SigningCredentials,
            NotBefore = issueTime,
            IssuedAt = issueTime
        };
    }
}