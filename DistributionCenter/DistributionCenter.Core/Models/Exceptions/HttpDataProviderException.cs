using System;
using System.Net;
using System.Runtime.Serialization;

namespace DistributionCenter.Core.Models.Exceptions
{
    [Serializable]
    public class HttpDataProviderException : Exception
    {
        private readonly HttpStatusCode? _httpStatusCode;
        public HttpStatusCode? HttpStatusCode { get { return _httpStatusCode; } }

        public HttpDataProviderException(string message)
            : base(message)
        {
        }

        public HttpDataProviderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public HttpDataProviderException(string message, Exception innerException, HttpStatusCode? httpStatusCode)
            : base(message, innerException)
        {
            _httpStatusCode = httpStatusCode;
        }

        protected HttpDataProviderException(SerializationInfo info, StreamingContext streamingContext)
            : base(info, streamingContext)
        {
        }
    }
}
