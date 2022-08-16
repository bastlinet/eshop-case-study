using Core.ApiPipeline.Controllers.Common;
using Eshop.Core.Contracts.Handlers.Products.V1.Detail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.Api.Controllers.V1.Product;

public partial class ProductController : ControllerApiBase
{
    /// <summary>
    /// Returns one product
    /// </summary>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>list of products</returns>
    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [MapToApiVersion("1.0")]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Returns one product", type: typeof(DetailProductResponse))]
    public async Task<IActionResult> Detail([FromRoute] DetailProductRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(mapper.Map<DetailProductQuery>(request), cancellationToken);
        return Ok(mapper.Map<DetailProductResponse>(result));
    }
}