using Eshop.Core.Logic;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eshop.Web.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddCore();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
