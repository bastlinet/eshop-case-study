using AspNetCore.Hashids.Json;
using AspNetCore.Hashids.Mvc;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Eshop.Web.Api.Controllers.V1.Product;

/// <summary>
/// Detail of products request
/// </summary>
[SwaggerSchema("Detail of products request")]
public class DetailProductRequest
{
    [Required]
    [FromRoute(Name = "id")]
    [SwaggerSchema("Id", Nullable = false)]
    [JsonConverter(typeof(LongHashidsJsonConverter))]
    [ModelBinder(typeof(HashidsModelBinder))]
    public long Id { get; set; }
}