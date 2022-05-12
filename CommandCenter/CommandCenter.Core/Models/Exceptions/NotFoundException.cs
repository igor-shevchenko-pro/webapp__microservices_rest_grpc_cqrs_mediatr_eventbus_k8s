using System;
using System.Runtime.Serialization;

namespace CommandCenter.Core.Models.Exceptions
{
    public sealed class NotFoundException : DomainException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private NotFoundException(SerializationInfo info, StreamingContext streamingContext)
            : base(info, streamingContext)
        {
        }
    }
}
