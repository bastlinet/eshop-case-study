using Swashbuckle.AspNetCore.Annotations;

namespace Core.ApiPipeline.Responses.V1;

/// <summary>
/// Standard pagination response
/// </summary>
public class PaginationResponse
{
    [SwaggerParameter(Description = "Number of total records")]
    public int TotalCount { get; set; }

    [SwaggerParameter(Description = "Number of filtered records")]
    public int FilteredCount { get; set; }
}
