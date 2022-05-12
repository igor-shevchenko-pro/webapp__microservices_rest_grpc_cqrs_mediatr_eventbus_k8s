using System;
using System.Runtime.Serialization;

namespace CommandCenter.Core.Models.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext streamingContext)
            : base(info, streamingContext)
        {
        }
    }
}
