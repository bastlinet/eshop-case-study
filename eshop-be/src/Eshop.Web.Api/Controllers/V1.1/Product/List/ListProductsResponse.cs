using Core.ApiPipeline.Responses.V1;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Api.Controllers.V1_1.Product;

/// <summary>
/// List of product response
/// </summary>
[SwaggerSchema("List of product")]
public class ListProductsResponse
{
    [Required]
    [SwaggerSchema("Pagination metadata", ReadOnly = true, Nullable = false)]
    public PaginationResponse Metadata { get; set; }

    [Required]
    [SwaggerSchema("List of product items", ReadOnly = true, Nullable = false)]
    public IEnumerable<ListProductResponse> Items { get; set; }
}