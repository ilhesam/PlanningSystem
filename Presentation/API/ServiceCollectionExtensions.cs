using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Planning System API",
                Version = "v1",
                Description = "<hr>Hello, This is Documentation of Planning System API V1" +
                              "<hr>DateTime Format: yyyy-MM-ddTHH:mm:ss"
            });

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        return services;
    }

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
        // services.AddJwtProvider(config.GetSection("Jwt").Get<JwtAuthenticationOptions>());
        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration config)
    {
        // var options = config.GetSection("Jwt").Get<JwtAuthenticationOptions>();
        //
        // services.AddAuthentication(configureOptions =>
        //     {
        //         configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //         configureOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //         configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //     })
        //     .AddJwtBearer(jwt =>
        //     {
        //         var key = Encoding.ASCII.GetBytes(options.Secret);
        //         jwt.SaveToken = true;
        //         jwt.TokenValidationParameters = new TokenValidationParameters
        //         {
        //             ValidateIssuerSigningKey = true,
        //             IssuerSigningKey = new SymmetricSecurityKey(key),
        //             ValidateIssuer = true,
        //             ValidateAudience = true,
        //             RequireExpirationTime = true,
        //             ValidateLifetime = true,
        //             SaveSigninToken = true,
        //             ValidAudience = options.Audience,
        //             ValidIssuer = options.Issuer
        //         };
        //     });
        //
        return services;
    }

    public static IServiceCollection AddBsonSerializers(this IServiceCollection services)
    {
        services.AddDefaultBsonSerializers();
        services.AddUserContextBsonSerializer<UserContext>();
        return services;
    }
}