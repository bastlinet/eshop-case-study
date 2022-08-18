using Core.ApiPipeline.Controllers.Common;
using Eshop.Core.Contracts.Handlers.Products.V1.Edit;
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
    [HttpPut]
    [MapToApiVersion("1.1")]
    [MapToApiVersion("1.0")]
    [SwaggerResponse(statusCode: StatusCodes.Status202Accepted, description: "Product was successfully updated")]
    [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Product was not found")]
    public async Task<IActionResult> Edit([FromBody] EditProductRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(mapper.Map<EditProductCommand>(request), cancellationToken);
        return AcceptOrNotFound(result.Count != 0);

    }
}