using Core.ApiPipeline.Controllers.Common;
using Eshop.Core.Contracts.Handlers.Products.V1.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.Api.Controllers.V1.Product;

public partial class ProductController : ControllerApiBase
{
    [HttpGet]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: null, type: typeof(ListProductsResponse))]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        var request = new ListProductRequest();
        var result = await mediator.Send(mapper.Map<ListProductQuery>(request), cancellationToken);
        return Ok(mapper.Map<ListProductsResponse>(result));
    }
}