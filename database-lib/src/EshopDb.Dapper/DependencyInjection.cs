using EshopDb.Contracts.Stores.Products;
using EshopDb.Dapper.Stores.Products;
using Microsoft.Extensions.DependencyInjection;

namespace EshopDb.Dapper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // providers
            services.AddScoped<IProductStore, ProductStore>();

            return services;
        }
    }
}