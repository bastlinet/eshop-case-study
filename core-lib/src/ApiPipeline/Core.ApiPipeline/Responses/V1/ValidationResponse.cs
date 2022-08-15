using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace Core.ApiPipeline.Responses.V1
{
    /// <summary>
    /// Standard API validation response
    /// </summary>
    public class ValidationResponse : ErrorResponse
    {
        public ValidationResponse()
        {
        }

        public ValidationResponse(string type, string title, int requestId, IDictionary<string, IEnumerable<string>> validations) : base(type, title, requestId)
        {
            Validations = validations;
        }

        /// <summary>
        /// Validations
        /// </summary>
        [SwaggerParameter(Description = "Collections of validation")]
        public IDictionary<string, IEnumerable<string>> Validations { get; }
    }
}
