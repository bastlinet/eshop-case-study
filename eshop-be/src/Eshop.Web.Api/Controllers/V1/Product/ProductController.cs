using AutoMapper;
using Core.ApiPipeline.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Api.Controllers.V1.Product;

/// <summary>
/// Controller for providing all endpoints for products
/// </summary>
[ApiVersion("1.1")]
[ApiVersion("1.0", Deprecated = true)]
[Route("api/v{version:apiVersion}/product")]
public partial class ProductController : ControllerApiBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public ProductController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }
}