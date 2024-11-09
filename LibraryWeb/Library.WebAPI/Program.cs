using Library.Core.DependencyInjection;
using Library.Data.Context;
using Library.Data.DependencyInjection;
using Library.Data.Models;
using Library.WebAPI.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Library.WebAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.Sources.Clear();

        builder.Configuration
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\Library.Data\\Context"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        builder.Services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddControllers();

        // Add CORS policy (allow specific or all origins)
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin() // This allows any domain (if security is not a concern)
                       .AllowAnyMethod() // This allows all HTTP methods (GET, POST, etc.)
                       .AllowAnyHeader(); // This allows all headers (for custom headers like Authorization)
            });
        });

        builder.Services.AddRepositories();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        builder.Services.AddServices();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseMiddleware<ExceptionMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Enable CORS
        app.UseCors("AllowAllOrigins");

        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}