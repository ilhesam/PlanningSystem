using AutoMapper;
using BCrypt;
using Core.Repository.MongoDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddUserContext();

builder.Services.AddCommon<BCryptPasswordHasher, AutoMapperProvider, MongoDbPaginator>();

builder.Services.AddBsonSerializers();

builder.Services.AddIdentification(builder.Configuration);
builder.Services.AddPlanning(builder.Configuration);

builder.Services.AddJwtProvider(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();