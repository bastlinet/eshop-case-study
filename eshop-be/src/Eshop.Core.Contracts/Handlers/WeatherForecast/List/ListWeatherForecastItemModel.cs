using System;

namespace Eshop.Core.Contracts.Handlers.WeatherForecast.List
{
    public class ListWeatherForecastItemModel
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
