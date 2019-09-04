using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Bookstore.Web.Extensions
{
    public static class MediatRSetup
    {
        public static void AddMediatRSetup(this IServiceCollection services) =>
            services.AddMediatR(Assembly.Load("AspNetCore.Bookstore.Domain"));
    }
}