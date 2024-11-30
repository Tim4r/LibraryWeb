using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Library.WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var endpoint = context.GetEndpoint();

            if (endpoint?.Metadata?.GetMetadata<AllowAnonymousAttribute>() != null)
            {
                await _next(context);
                return;
            }

            var accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(accessToken))
            {
                _logger.LogWarning("Security token is missing...");
                await HandleTokenNullAsync(context);
                return;
            }

            ClaimsPrincipal? principal;
            try
            {
                principal = ValidateToken(accessToken, context);
            }
            catch(SecurityTokenValidationException ex)
            {
                _logger.LogWarning("The secret token is not valid...");
                await HandleTokenInvalidAsync(context, ex);
                return;
            }

            context.User = principal;

            await _next(context); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred...");
            await HandleExceptionAsync(context, ex);
        }
    }

    private ClaimsPrincipal? ValidateToken(string token, HttpContext context)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(context.RequestServices.GetRequiredService<IConfiguration>()["JWT:SigningKey"])
            ),
            ValidateIssuer = true,
            ValidIssuer = context.RequestServices.GetRequiredService<IConfiguration>()["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = context.RequestServices.GetRequiredService<IConfiguration>()["JWT:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
    }

    private static Task HandleTokenNullAsync(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = StatusCodes.Status401Unauthorized;

        var result = JsonSerializer.Serialize(new { error = "Token is missing, please re-try request with security token!" });
        return response.WriteAsync(result);
    }

    private static Task HandleTokenInvalidAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = StatusCodes.Status401Unauthorized;

        var result = JsonSerializer.Serialize(new { error = $"{exception.Message}" });
        return response.WriteAsync(result);
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new { error = "An unexpected error occurred.", detail = exception.Message });
        return response.WriteAsync(result);
    }
}
