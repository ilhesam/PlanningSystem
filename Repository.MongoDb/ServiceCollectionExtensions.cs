using Repository;
using Repository.MongoDb;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDbIdentification(this IServiceCollection services, MongoDbOptions options)
    {
        services.AddSingleton(new MongoDbOptions<IdentificationMongoDbContext>
        {
            ConnectionString = options.ConnectionString
        });

        services.AddSingleton<IdentificationMongoDbContext>();

        services.AddScoped<IUserRepository, MongoDbUserRepository<IdentificationMongoDbContext>>();

        return services;
    }

    public static IServiceCollection AddMongoDbPlanning(this IServiceCollection services, MongoDbOptions options)
    {
        services.AddSingleton(new MongoDbOptions<PlanningMongoDbContext>
        {
            ConnectionString = options.ConnectionString
        });

        services.AddSingleton<PlanningMongoDbContext>();

        services.AddScoped<IPlanRepository, MongoDbPlanRepository<PlanningMongoDbContext>>();
        services.AddScoped<ITargetRepository, MongoDbTargetRepository<PlanningMongoDbContext>>();
        services.AddScoped<IMetricRepository, MongoDbMetricRepository<PlanningMongoDbContext>>();

        return services;
    }
}