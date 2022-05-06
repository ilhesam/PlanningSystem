namespace RazorPages.Authentication;

public static class HttpContextExtensions
{
    public static void SignIn(this HttpContext httpContext, string accessToken)
    {
        httpContext.SaveAccessToken(accessToken);
    }

    public static void SignOut(this HttpContext httpContext)
    {
        httpContext.RemoveAccessToken();
    }

    public static void SaveAccessToken(this HttpContext httpContext, string accessToken)
    {
        httpContext.Response.Cookies.Append(JwtAuthenticationConstants.AccessTokenKey, accessToken, new CookieOptions
        {
            Expires = JwtHelper.GetExpirationDateTime(accessToken)
        });
    }

    public static void RemoveAccessToken(this HttpContext httpContext)
    {
        httpContext.Response.Cookies.Delete(JwtAuthenticationConstants.AccessTokenKey);
    }

    public static string GetAccessToken(this HttpContext httpContext)
        => httpContext.Request.Cookies.FirstOrDefault(e => e.Key == JwtAuthenticationConstants.AccessTokenKey).Value;
}