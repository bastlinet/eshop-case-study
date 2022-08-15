using System;

namespace Eshop.Core.Contracts.Providers.WeatherForecast
{
    public class ListWeatherForecastOutputModel
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
