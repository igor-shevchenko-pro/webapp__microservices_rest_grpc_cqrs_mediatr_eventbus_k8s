using System.Threading;

namespace CommandCenter.API.Middlewares.CorrelationId
{
    public class CorrelationIdContext
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
