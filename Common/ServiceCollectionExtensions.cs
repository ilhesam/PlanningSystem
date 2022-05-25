using Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class CommonExtensions
{
    public static IServiceCollection AddCommon<TPasswordHasher, TMappingProvider, TPaginator>(this IServiceCollection services)
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