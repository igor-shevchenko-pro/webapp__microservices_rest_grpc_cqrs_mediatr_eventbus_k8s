using System.Threading;

namespace DistributionCenter.Core.Contexts.CorrelationId
{
    public abstract class CorrelationIdContext
    {
        private static readonly AsyncLocal<string> _correlationId = new AsyncLocal<string>();

        public static void SetCorrelationId(string correlationId)
        {
            _correlationId.Value = correlationId;
        }

        public static string? GetCorrelationId()
        {
            return _correlationId.Value;
        }
    }
}
