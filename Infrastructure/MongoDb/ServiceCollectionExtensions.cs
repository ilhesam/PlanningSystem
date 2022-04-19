using Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Repository;
using Repository.MongoDb;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDefaultBsonSerializers(this IServiceCollection services)
    {
        BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
        BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(GuidRepresentation.Standard));
        BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
        BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));

        return services;
    }

    public static IServiceCollection AddUserContextBsonSerializer<TUserContext>(this IServiceCollection services)
        where TUserContext : IUserContext
    {
        BsonSerializer.RegisterSerializer(typeof(IUserContext), new UserContextBsonSerializer<TUserContext>());

        return services;
    }

    public static IServiceCollection AddMongoDbIdentification(this IServiceCollection services, MongoDbOptions options)
    {
        services.AddSingleton(new MongoDbOptions<IdentificationMongoDbContext>
        {
            ConnectionString = options.ConnectionString
        });

        services.AddSingleton<IdentificationMongoDbContext>();

        services.AddSingleton<IMongoCollectionConfiguration<User>, UserConfiguration>();

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

        services.AddSingleton<IMongoCollectionConfiguration<Plan>, PlanConfiguration>();
        services.AddSingleton<IMongoCollectionConfiguration<Target>, TargetConfiguration>();
        services.AddSingleton<IMongoCollectionConfiguration<Metric>, MetricConfiguration>();

        services.AddScoped<IPlanRepository, MongoDbPlanRepository<PlanningMongoDbContext>>();
        services.AddScoped<ITargetRepository, MongoDbTargetRepository<PlanningMongoDbContext>>();
        services.AddScoped<IMetricRepository, MongoDbMetricRepository<PlanningMongoDbContext>>();

        return services;
    }
}