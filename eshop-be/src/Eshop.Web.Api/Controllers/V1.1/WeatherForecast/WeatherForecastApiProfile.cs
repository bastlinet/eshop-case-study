using AutoMapper;
using Eshop.Core.Contracts.Handlers.WeatherForecast.List;

namespace Eshop.Web.Api.Controllers.V1_1.WeatherForecast;

public class WeatherForecastApiProfile : Profile
{
    public WeatherForecastApiProfile()
    {
        CreateMap<ListWeatherForecastRequest, ListWeatherForecastQuery>();
        CreateMap<ListWeatherForecastModel, ListWeatherForecastsResponse>();
        CreateMap<ListWeatherForecastItemModel, ListWeatherForecastResponse>();
    }
}
