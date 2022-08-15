using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.ApiPipeline.Responses.V1
{
    /// <summary>
    /// Standard API error response
    /// </summary>
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(string type, string title, int requestId)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            RequestId = requestId;
        }

        /// <summary>
        /// Error type
        /// </summary>
        [Required]
        [SwaggerParameter(Description = "Error type")]
        public string Type { get; set; }

        /// <summary>
        /// Error title
        /// </summary>
        [Required]
        [SwaggerParameter(Description = "Error title")]
        public string Title { get; set; }

        /// <summary>
        /// Request ID
        /// </summary>
        [Required]
        [SwaggerParameter(Description = "Request ID")]
        public int RequestId { get; set; }
    }
}
