using Microsoft.Data.SqlClient;

namespace backend_csharp.Middleware;

public sealed class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentException ex)
        {
            await WriteJsonAsync(context, StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "SQL error while processing request {Path}", context.Request.Path);
            await WriteJsonAsync(context, StatusCodes.Status500InternalServerError, "Co loi khi xu ly du lieu. Vui long thu lai.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled error while processing request {Path}", context.Request.Path);
            await WriteJsonAsync(context, StatusCodes.Status500InternalServerError, "Co loi he thong. Vui long thu lai sau.");
        }
    }

    public static async Task WriteJsonAsync(HttpContext context, int statusCode, string message)
    {
        if (context.Response.HasStarted)
        {
            return;
        }

        context.Response.Clear();
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json; charset=utf-8";
        await context.Response.WriteAsJsonAsync(new
        {
            message,
            status = statusCode
        });
    }
}
