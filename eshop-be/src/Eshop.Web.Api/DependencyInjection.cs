using AspNetCore.Hashids.Options;
using Eshop.Core.Logic;
using Eshop.Web.Api.Filters;
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
        services
            .AddCore()
            .AddDatabase(configuration)
            .AddWebApiHashids(configuration);

        services
            .AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddWebApiHashids(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHashids((opt) =>
        {
            configuration.GetSection(nameof(HashidsOptions)).Bind(opt);
        })
        .AddSwaggerGen(c => c.OperationFilter<HashidsOperationFilter>());

        return services;
    }
}
