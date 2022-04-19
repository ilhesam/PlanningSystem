using Core;
using Core.Authentication.Jwt;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJwtProvider(this IServiceCollection services, JwtAuthenticationOptions options)
    {
        services.AddSingleton(options);

        services.AddScoped<IAuthenticationProvider, JwtAuthenticationProvider>();
        services.AddScoped<IJwtClaimsProvider, JwtClaimsProvider>();

        return services;
    }
}