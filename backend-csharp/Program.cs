using backend_csharp.Middleware;
using backend_csharp.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var firstError = context.ModelState.Values
            .SelectMany(value => value.Errors)
            .Select(error => string.IsNullOrWhiteSpace(error.ErrorMessage)
                ? "Du lieu gui len khong hop le."
                : error.ErrorMessage)
            .FirstOrDefault() ?? "Du lieu gui len khong hop le.";

        return new BadRequestObjectResult(new
        {
            message = firstError,
            status = StatusCodes.Status400BadRequest
        });
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "QLBH Take Away C# API",
        Version = "v1"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhap JWT theo dang: Bearer {token}"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});
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

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton<JwtTokenService>();
builder.Services
    .AddAuthentication("Bearer")
    .AddScheme<AuthenticationSchemeOptions, JwtAuthenticationHandler>("Bearer", null);
builder.Services.AddAuthorization(AuthorizationPolicies.AddQlbPolicies);

builder.Services.AddSingleton<backend_csharp.Data.DbConnectionFactory>();
builder.Services.AddScoped<backend_csharp.Services.AuthService>();
builder.Services.AddScoped<backend_csharp.Services.CatalogService>();
builder.Services.AddScoped<backend_csharp.Services.SalesService>();
builder.Services.AddScoped<backend_csharp.Services.InventoryService>();
builder.Services.AddScoped<backend_csharp.Services.ReportService>();
builder.Services.AddScoped<backend_csharp.Services.DatabaseSetupService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseStatusCodePages(async statusCodeContext =>
{
    var response = statusCodeContext.HttpContext.Response;
    if (response.StatusCode is StatusCodes.Status401Unauthorized or StatusCodes.Status403Forbidden)
    {
        var message = response.StatusCode == StatusCodes.Status401Unauthorized
            ? "Phien dang nhap khong hop le hoac da het han."
            : "Ban khong co quyen thuc hien chuc nang nay.";
        await ErrorHandlingMiddleware.WriteJsonAsync(statusCodeContext.HttpContext, response.StatusCode, message);
    }
});

app.UseCors("VueFrontend");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "QLBH Take Away C# API v1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/api/health", () => Results.Ok(new
{
    service = "QLBH Take Away C# API",
    status = "running",
    database = "QLBH_TAKEAWAY"
}));

app.MapControllers();

app.Run();
