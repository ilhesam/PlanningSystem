using Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure<TPasswordHasher, TMappingProvider, TPaginator>(this IServiceCollection services)
        where TPasswordHasher : class, IPasswordHasher
        where TMappingProvider : class, IMappingProvider
        where TPaginator : class, IPaginator
    {
        services.AddScoped<IPasswordHasher, TPasswordHasher>();
        services.AddScoped<IMappingProvider, TMappingProvider>();
        services.AddScoped<IPaginator, TPaginator>();

        return services;
    }
}