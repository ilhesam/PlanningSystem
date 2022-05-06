namespace RazorPages.Authentication;

public class UnauthorizedRedirectionMiddleware
{
    private readonly RequestDelegate _next;

    public UnauthorizedRedirectionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);
        RedirectIfUnauthorized(context);
    }

    private static void RedirectIfUnauthorized(HttpContext context)
    {
        if (context.Response.StatusCode == 401) context.Response.Redirect("/Accounts/Login");
    }
}

public static class UnauthorizedRedirectionMiddlewareExtensions
{
    public static IApplicationBuilder UseUnauthorizedRedirection(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<UnauthorizedRedirectionMiddleware>();
        return builder;
    }
}