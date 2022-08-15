using AutoMapper;
using Eshop.Core.Contracts.Handlers.WeatherForecast.List;
using Eshop.Core.Contracts.Providers.WeatherForecast;

namespace Eshop.Core.Logic.Handlers.WeatherForecast
{
    /// <summary>
    /// Register mapping for weatherforcast handlers
    /// </summary>
    public partial class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<ListWeatherForecastQuery, ListWeatherForecastInputModel>();
            CreateMap<ListWeatherForecastOutputModel, ListWeatherForecastItemModel>();
        }
    }
}
