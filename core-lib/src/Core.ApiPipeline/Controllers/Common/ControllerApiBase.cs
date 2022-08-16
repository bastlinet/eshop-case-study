using Core.ApiPipeline.Responses.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.ApiPipeline.Controllers.Common;

/// <summary>
/// <inheritdoc/>
/// </summary>
[ApiController]
[SwaggerResponse(statusCode: StatusCodes.Status204NoContent)]
[SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type: typeof(ValidationResponse))]
[SwaggerResponse(statusCode: StatusCodes.Status403Forbidden, type: typeof(ErrorResponse))]
public abstract class ControllerApiBase : ControllerBase
{
    // TODO make it better
    protected virtual IActionResult AcceptOrNotFound(bool isAccepted)
    {
        if (isAccepted)
        {
            return Accepted();
        }
        else
        {
            return NotFound();
        }
    }
}
