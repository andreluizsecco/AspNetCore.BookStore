using AspNetCore.Bookstore.Data.Repositories;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Bookstore.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}