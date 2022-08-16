using Eshop.Core.Logic;
using EshopDb.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eshop.Web.Api;

/// <summary>
/// Extending dependency injection for EshopDb.Web.Api
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore()
            .AddDatabase(configuration);

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
