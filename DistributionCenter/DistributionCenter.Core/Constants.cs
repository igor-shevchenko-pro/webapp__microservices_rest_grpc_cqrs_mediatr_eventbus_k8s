using System.Collections;
using System.Collections.Generic;

namespace DistributionCenter.Core
{
    public static class Constants
    {
        public static class HttpContextHeaderKeys
        {
            public const string CORRELATION_ID = "X-Correlation-ID";
            public const string API_VERSION = "X-Api-Version";
        }

        public static class SwaggerConfigurations
        {
            public const string TITLE = "DistributionCenter API";
            public const string DESCRIPTION = "This is a Web API for DistributionCenter operations.";
            public const string TERMS_OF_SERVICE_URL = "https://www.linkedin.com/in/igor-shevchenko-pro/";
            public const string LICENSE_NAME = "MIT";
            public const string CONTACT_NAME = "Igor Shevchenko";
            public const string CONTACT_EMAIL = "igor.shevchenko.pro@gmail.com";
            public const string CONTACT_URL = "https://github.com/igor-shevchenko-pro/";
        }

        public const string DEFAULT_ERROR_MESSAGE = "An unexpected error occured";

        public static readonly string[] BASE_PROPERTIES_TO_SKIP_WHEN_COPY = { "Id", "Created", "Updated" };

        public static Dictionary<int, string> STATUS_CODE_TYPES = new Dictionary<int, string>()
        {
            { 100, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.2.1"},
            { 101, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.2.2"},
            { 200, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.1"},
            { 201, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.2"},
            { 202, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.3"},
            { 203, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.4"},
            { 204, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.5"},
            { 205, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.6"},
            { 300, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.1"},
            { 301, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.2"},
            { 302, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.3"},
            { 303, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.4"},
            { 305, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.5"},
            { 306, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.6"},
            { 307, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.7"},
            { 400, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"},
            { 402, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.2"},
            { 403, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3"},
            { 404, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"},
            { 405, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.5"},
            { 406, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.6"},
            { 408, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.7"},
            { 409, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8"},
            { 410, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9"},
            { 411, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.10"},
            { 413, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.11"},
            { 414, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.12"},
            { 415, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.13"},
            { 417, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.14"},
            { 426, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.15"},
            { 500, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"},
            { 501, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.2"},
            { 502, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.3"},
            { 503, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4"},
            { 504, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.5"},
            { 505, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.6"}
        };
    }
}
