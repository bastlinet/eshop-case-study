using System;

namespace Eshop.Web.Api.Controllers.V1.WeatherForecast;

public class ListWeatherForecastResponse
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; set; }
}