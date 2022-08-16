using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Core.ApiPipeline.Requests.V1;

/// <summary>
/// Standard pagination request
/// </summary>
public class PaginationRequest
{
    /// <summary>
    /// Number of records in page
    /// </summary>
    [DefaultValue(10)]
    [SwaggerParameter(Description = "Number of records in page")]
    [FromQuery(Name = "limit")]
    public int Limit { get; set; } = 10;

    /// <summary>
    /// Number of skipped records
    /// </summary>
    [DefaultValue(0)]
    [SwaggerParameter(Description = " Number of skipped records")]
    [FromQuery(Name = "offset")]
    public int Offset { get; set; } = 0;
}
