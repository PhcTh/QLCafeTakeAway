var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<backend_csharp.Data.DbConnectionFactory>();
builder.Services.AddScoped<backend_csharp.Services.AuthService>();
builder.Services.AddScoped<backend_csharp.Services.CatalogService>();
builder.Services.AddScoped<backend_csharp.Services.SalesService>();
builder.Services.AddScoped<backend_csharp.Services.InventoryService>();
builder.Services.AddScoped<backend_csharp.Services.ReportService>();
builder.Services.AddScoped<backend_csharp.Services.DatabaseSetupService>();

var app = builder.Build();

app.UseCors("VueFrontend");

app.UseAuthorization();

app.MapGet("/api/health", () => Results.Ok(new
{
    service = "QLBH Take Away C# API",
    status = "running",
    database = "QLBH_TAKEAWAY"
}));

app.MapControllers();

app.Run();
