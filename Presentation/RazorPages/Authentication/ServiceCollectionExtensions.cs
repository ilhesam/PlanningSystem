namespace RazorPages.Authentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtAuthenticationConstants.AuthenticationScheme;
        }).AddScheme<JwtAuthenticationSchemeOptions, JwtAuthenticationHandler>(JwtAuthenticationConstants.AuthenticationScheme, _ => {});

        return services;
    }
}