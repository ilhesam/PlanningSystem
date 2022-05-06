var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddUserContext();

builder.Services.AddBCryptPasswordHasher();

builder.Services.AddBsonSerializers();

builder.Services.AddIdentification(builder.Configuration);
builder.Services.AddPlanning(builder.Configuration);

builder.Services.AddJwtProvider(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddAutoMapper();

builder.Services.AddRequiredServices();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseUnauthorizedRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
