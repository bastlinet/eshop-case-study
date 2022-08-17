using AspNetCore.Hashids.Json;
using AspNetCore.Hashids.Mvc;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Eshop.Web.Api.Controllers.V1.Product;

/// <summary>
/// Edit product description
/// </summary>
[SwaggerSchema("Edit product description")]
public class EditProductRequest
{
    [Required]
    [SwaggerSchema("Id", Nullable = false)]
    [JsonConverter(typeof(LongHashidsJsonConverter))]
    [ModelBinder(typeof(HashidsModelBinder))]
    public long Id { get; set; }

    [FromBody]
    [SwaggerSchema("Description", Nullable = true)]
    public string Description { get; set; }
}