using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Library.Data.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
{
    public ApplicationDBContext CreateDbContext(string[] args)
    {
        var configPath = @"D:\Repositories\LibraryWeb\LibraryWeb\Library.Data\Context";

        // Build configuration from appsettings.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(configPath)
            .AddJsonFile("appsettings.json")
            .Build();

        // Get the connection string from the configuration
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Configure DbContextOptions
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationDBContext(optionsBuilder.Options);
    }
}
