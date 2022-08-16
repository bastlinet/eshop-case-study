using AutoMapper;
using Eshop.Core.Contracts.Handlers.WeatherForecast.List;

namespace Eshop.Web.Api.Controllers.V1_1.WeatherForecast;

/// <summary>
/// Automapper product API profile for custom mapping of WeatherForecast's objects
/// </summary>
public class WeatherForecastApiProfile : Profile
{
    public WeatherForecastApiProfile()
    {
        CreateMap<ListWeatherForecastRequest, ListWeatherForecastQuery>();
        CreateMap<ListWeatherForecastModel, ListWeatherForecastsResponse>();
        CreateMap<ListWeatherForecastItemModel, ListWeatherForecastResponse>();
    }
}
