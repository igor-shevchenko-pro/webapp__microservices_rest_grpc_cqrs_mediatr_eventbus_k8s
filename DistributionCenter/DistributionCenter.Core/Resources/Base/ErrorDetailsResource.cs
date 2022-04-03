using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace DistributionCenter.Core.Resources.Base
{
    public class ErrorDetailsResource
    {
        /// <summary>
        /// Error type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Error status
        /// </summary>
        [JsonProperty("status")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Error title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Error detail
        /// </summary>
        [JsonProperty("detail")]
        public string? Detail { get; set; }

        /// <summary>
        /// Validation errors
        /// </summary>
        [JsonProperty("errors")]
        public IReadOnlyDictionary<string, IEnumerable<string>>? Errors { get; set; } = new Dictionary<string, IEnumerable<string>>();

        public ErrorDetailsResource(
            int statusCode, 
            string title, 
            string? detail)
        {
            Type = Constants.STATUS_CODE_TYPES[statusCode];
            StatusCode = statusCode;
            Title = title;
            Detail = detail;
        }

        public ErrorDetailsResource(
            int statusCode,
            string title,
            string? detail,
            IReadOnlyDictionary<string, IEnumerable<string>>? errors)
            : this(statusCode, title, detail)
        {
            Errors = errors;
        }
    }
}
