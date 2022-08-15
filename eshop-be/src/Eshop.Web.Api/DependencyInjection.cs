using Eshop.Core.Logic;
using EshopDb.Dapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eshop.Web.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddCore()
            .AddDatabase();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
