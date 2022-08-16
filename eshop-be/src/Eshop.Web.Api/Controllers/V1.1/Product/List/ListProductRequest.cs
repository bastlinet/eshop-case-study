using Core.ApiPipeline.Requests.V1;
using Swashbuckle.AspNetCore.Annotations;

namespace Eshop.Web.Api.Controllers.V1_1.Product;

/// <summary>
/// List of products request
/// </summary>
[SwaggerSchema("List of product request")]
public class ListProductRequest : PaginationRequest
{
}