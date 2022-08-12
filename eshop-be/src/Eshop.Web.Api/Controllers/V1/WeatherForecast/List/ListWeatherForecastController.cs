using Core.ApiPipeline.Controllers.Common;
using Eshop.Core.Contracts.Handlers.WeatherForecast.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.Api.Controllers.V1.WeatherForecast;

public partial class WeatherForecastController : ControllerApiBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ListWeatherForecastsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> List(ListWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(mapper.Map<ListWeatherForecastQuery>(request), cancellationToken);
        return Ok(mapper.Map<ListWeatherForecastsResponse>(result));
    }
}