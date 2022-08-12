using Eshop.Core.Contracts.Providers.WeatherForecast;
using Eshop.Core.Logic.Providers.WeatherForecast;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eshop.Core.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // providers
            services.AddScoped<IWeatherForecastProvider, WeatherForecastProvider>();

            return services;
        }
    }
}