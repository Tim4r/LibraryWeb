using System.Net;
using System.Text.Json;

namespace Library.WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized &&
                context.Response.Headers.ContainsKey("Token-Expired"))
            {
                await HandleTokenExpirationAsync(context);
            }
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new { error = "An unexpected error occurred.", detail = exception.Message });

        return response.WriteAsync(result);
    }

    private static Task HandleTokenExpirationAsync(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(new { error = "Token has expired, please re-authenticate." });

        return context.Response.WriteAsync(result);
    }
}
