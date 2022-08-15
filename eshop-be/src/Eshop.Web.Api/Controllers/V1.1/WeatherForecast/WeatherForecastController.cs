using AutoMapper;
using Core.ApiPipeline.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Api.Controllers.V1_1.WeatherForecast;

[ApiVersion("1.1")]
[Route("api/v{version:apiVersion}/weatherforecast")]
public partial class WeatherForecastController : ControllerApiBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public WeatherForecastController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }
}