using System;
using System.Net;
using System.Runtime.Serialization;

namespace DistributionCenter.Core.Models.Exceptions
{
    public class UnsupportedApiVersionException : Exception
    {
        private readonly HttpStatusCode? _httpStatusCode;
        public HttpStatusCode? HttpStatusCode { get { return _httpStatusCode; } }

        public UnsupportedApiVersionException(string message)
            : base(message)
        {
        }

        public UnsupportedApiVersionException(string message, HttpStatusCode httpStatusCode)
            : base(message)
        {
            _httpStatusCode = httpStatusCode;
        }

        public UnsupportedApiVersionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UnsupportedApiVersionException(string message, Exception innerException, HttpStatusCode httpStatusCode)
            : base(message, innerException)
        {
            _httpStatusCode = httpStatusCode;
        }

        protected UnsupportedApiVersionException(SerializationInfo info, StreamingContext streamingContext)
            : base(info, streamingContext)
        {
        }
    }
}
