using Library.Data.Context;
using Library.Data.Repository;
using Library.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Data.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddApplicationDbContext(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<ApplicationDBContext>(s => s.UseSqlServer(connectionString));
    }

    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IBookRepository, BookRepository>();
    }
}
