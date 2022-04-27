using BCrypt;
using Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBCryptPasswordHasher(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();

        return services;
    }
}