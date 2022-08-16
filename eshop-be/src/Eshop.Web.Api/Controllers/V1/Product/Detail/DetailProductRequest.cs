using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

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
    public long Id { get; set; }
}