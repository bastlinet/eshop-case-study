using EshopDb.Common;
using EshopDb.Contracts.Stores.Products;
using EshopDb.Dapper.Stores.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EshopDb.Dapper
{
    /// <summary>
    /// Extending dependency injection for EshopDb.Dapper library
    /// </summary>
    public static class DependencyInjection
    {
        public const string CONNECTIONSTRING = "EshopDb";
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var dbContext = new DatabaseContextOption
            {
                ConnectionString = configuration.GetConnectionString(CONNECTIONSTRING)
            };
            services.AddSingleton(dbContext);

            // providers
            services.AddScoped<IProductStore, ProductStore>();

            return services;
        }
    }
}