using API;
using Domain;
using Repository.MongoDb;
using Service;
using Service.Jwt;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();