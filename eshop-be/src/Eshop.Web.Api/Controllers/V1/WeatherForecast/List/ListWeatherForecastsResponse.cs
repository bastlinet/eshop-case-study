using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Api.Controllers.V1.WeatherForecast;

public class ListWeatherForecastsResponse
{
    // [SwaggerSchema("Itemz ...")]
    [Required]
    public IEnumerable<ListWeatherForecastResponse> Items { get; set; }
}