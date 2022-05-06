namespace RazorPages;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserContext(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();
        return services;
    }

    public static IServiceCollection AddIdentification(this IServiceCollection services, IConfiguration config)
    {
        services.AddMongoDbIdentification(config.GetSection("Identification:MongoDB").Get<MongoDbOptions>());
        return services;
    }

    public static IServiceCollection AddPlanning(this IServiceCollection services, IConfiguration config)
    {
        services.AddMongoDbPlanning(config.GetSection("Planning:MongoDB").Get<MongoDbOptions>());
        return services;
    }

    public static IServiceCollection AddJwtProvider(this IServiceCollection services, IConfiguration config)
    {
        services.AddJwtProvider(config.GetSection("Jwt").Get<JwtAuthenticationOptions>());
        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration config)
    {
        services.AddJwtAuthentication();
        return services;
    }

    public static IServiceCollection AddBsonSerializers(this IServiceCollection services)
    {
        services.AddDefaultBsonSerializers();
        services.AddUserContextBsonSerializer<UserContext>();
        return services;
    }
}