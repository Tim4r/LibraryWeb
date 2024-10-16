using Library.BL.Services;
using Library.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Core.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IBookService, BookService>();
    }
}
