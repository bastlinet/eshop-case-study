using System.Collections.Generic;

namespace Eshop.Core.Contracts.Handlers.WeatherForecast.List
{
    public class ListWeatherForecastModel
    {
        public IEnumerable<ListWeatherForecastItemModel> Items { get; set; }
    }
}