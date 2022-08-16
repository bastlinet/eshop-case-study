using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Api.Controllers.V1.Product;

/// <summary>
/// List of product response
/// </summary>
public class ListProductsResponse
{
    [Required]
    [SwaggerSchema("List of product items", ReadOnly = true, Nullable = false)]
    public IEnumerable<ListProductResponse> Items { get; set; }
}