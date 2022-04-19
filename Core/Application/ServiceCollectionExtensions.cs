using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRequiredServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}