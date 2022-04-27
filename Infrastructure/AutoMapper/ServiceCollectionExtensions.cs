using AutoMapper;
using Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMappingProvider, AutoMapperProvider>();

        return services;
    }
}