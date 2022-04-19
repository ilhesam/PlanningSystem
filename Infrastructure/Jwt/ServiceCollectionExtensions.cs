using Microsoft.Extensions.DependencyInjection;

namespace Service.Jwt;

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