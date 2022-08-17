using AspNetCore.Hashids.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Eshop.Web.Api.Controllers.V1.Product;

/// <summary>
/// List of product items response
/// </summary>
[SwaggerSchema("List of product items")]
public class ListProductResponse
{
    [Required]
    [SwaggerSchema("Id", ReadOnly = true, Nullable = false)]
    [JsonConverter(typeof(LongHashidsJsonConverter))]
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