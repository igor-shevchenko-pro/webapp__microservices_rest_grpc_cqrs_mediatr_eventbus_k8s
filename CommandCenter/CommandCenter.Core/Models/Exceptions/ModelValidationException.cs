using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CommandCenter.Core.Models.Exceptions
{
    [Serializable]
    public sealed class ModelValidationException : DomainException
    {
        private IReadOnlyDictionary<string, IEnumerable<string>> _errors = new Dictionary<string, IEnumerable<string>>();

        public IReadOnlyDictionary<string, IEnumerable<string>> Errors
        {
            get { return _errors; }
        }

        public ModelValidationException(string message, IReadOnlyDictionary<string, IEnumerable<string>> errors)
            : base(message)
        {
            _errors = errors;
        }

        public ModelValidationException(string message, IReadOnlyDictionary<string, IEnumerable<string>> errors, Exception innerException)
            : base(message, innerException)
        {
            _errors = errors;
        }

        private ModelValidationException(SerializationInfo info, StreamingContext streamingContext)
            : base(info, streamingContext)
        {
            _errors = (IReadOnlyDictionary<string, IEnumerable<string>>)info?.GetValue("Errors", typeof(IReadOnlyDictionary<string, IEnumerable<string>>));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("SerializationInfo is NULL");
            }

            info.AddValue("Errors", Errors, typeof(IReadOnlyList<string>));
            base.GetObjectData(info, context);
        }
    }
}
