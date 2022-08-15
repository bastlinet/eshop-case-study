using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.ApiPipeline.Requests.V1
{
    public class PaginationRequest
    {
        /// <summary>
        /// Number of records in page.
        /// </summary>
        /// <example>10</example>
        [DefaultValue(10)]
        [Range(1, int.MaxValue)]
        [SwaggerParameter(Description = "Number of records in page.")]
        [FromQuery(Name = "limit")]
        public int Limit { get; set; } = 10;

        /// <summary>
        /// Number of skipped records.
        /// </summary>
        /// <example>0</example>
        [DefaultValue(0)]
        [SwaggerParameter(Description = " Number of skipped records.")]
        [Range(0, int.MaxValue)]
        [FromQuery(Name = "offset")]
        public int Offset { get; set; } = 0;
    }
}
