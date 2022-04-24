using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();

builder.Services.AddDefaultBsonSerializers();
builder.Services.AddUserContextBsonSerializer<UserContext>();

builder.Services.AddMongoDbIdentification(builder.Configuration.GetSection("Identification:MongoDB").Get<MongoDbOptions>());
builder.Services.AddMongoDbPlanning(builder.Configuration.GetSection("Planning:MongoDB").Get<MongoDbOptions>());

builder.Services.AddJwtProvider(builder.Configuration.GetSection("Jwt").Get<JwtAuthenticationOptions>());

builder.Services.AddRequiredServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();