using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Api.Controllers.V1.Product;

public class ListProductsResponse
{
    // [SwaggerSchema("Itemz ...")]
    [Required]
    public IEnumerable<ListProductResponse> Items { get; set; }
}