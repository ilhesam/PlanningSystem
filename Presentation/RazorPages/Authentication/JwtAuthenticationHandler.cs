using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace RazorPages.Authentication;

public class JwtAuthenticationHandler : AuthenticationHandler<JwtAuthenticationSchemeOptions>
{
    public JwtAuthenticationHandler(IOptionsMonitor<JwtAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        => await Task.Run(() =>
        {
            var accessToken = Context.GetAccessToken();
            if (accessToken == null) return AuthenticateResult.Fail("Access token is null");

            var jwt = JwtHelper.Decode(accessToken);

            var claimsIdentity = new ClaimsIdentity(jwt.Claims, JwtAuthenticationConstants.AuthenticationType);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        });
}