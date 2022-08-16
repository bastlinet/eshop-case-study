using Core.ApiPipeline.Controllers.Common;
using Eshop.Core.Contracts.Handlers.Products.V1_1.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.Api.Controllers.V1_1.Product;

public partial class ProductController : ControllerApiBase
{
    /// <summary>
    /// Returns full list of products
    /// </summary>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>list of products</returns>
    [HttpGet]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Returns full list of products", type: typeof(ListProductsResponse))]
    public async Task<IActionResult> List([FromQuery] ListProductRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(mapper.Map<ListProductQuery>(request), cancellationToken);
        return Ok(mapper.Map<ListProductsResponse>(result));
    }
}