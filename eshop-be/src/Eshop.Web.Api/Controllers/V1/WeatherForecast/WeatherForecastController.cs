using AutoMapper;
using Core.ApiPipeline.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Api.Controllers.V1.WeatherForecast;

[ApiVersion("1.0", Deprecated = true)]
[Route("api/v{version:apiVersion}/weatherforcast")]
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