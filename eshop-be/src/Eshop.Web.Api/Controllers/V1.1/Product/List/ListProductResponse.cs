using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Api.Controllers.V1_1.Product;

/// <summary>
/// List of product items response
/// </summary>
[SwaggerSchema("List of product items")]
public class ListProductResponse
{
    [Required]
    [SwaggerSchema("Id", ReadOnly = true, Nullable = false)]
    public long Id { get; set; }

    [Required]
    [SwaggerSchema("Name", ReadOnly = true, Nullable = false)]
    public string Name { get; set; }

    [Required]
    [SwaggerSchema("Image URI", ReadOnly = true, Nullable = false)]
    public string ImgUri { get; set; }

    [Required]
    [SwaggerSchema("Price", ReadOnly = true, Nullable = false)]
    public decimal Price { get; set; }

    [SwaggerSchema("Description", ReadOnly = true, Nullable = true)]
    public string Description { get; set; }
}