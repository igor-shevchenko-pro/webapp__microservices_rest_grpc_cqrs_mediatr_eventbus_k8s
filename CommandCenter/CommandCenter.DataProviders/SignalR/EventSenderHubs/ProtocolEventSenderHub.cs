using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs;
using CommandCenter.Core.Resources;
using CommandCenter.DataProviders.SignalR.EventSenderHubs.Base;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.EventSenderHubs
{
    /// <summary>
    /// SignalR ProtocolEventSenderHub
    /// </summary>
    public class ProtocolEventSenderHub : BaseEventSenderHub<ProtocolGetResource>, IProtocolEventSenderHub
    {
        /// <summary>
        /// Constructor of ProtocolEventSenderHub
        /// </summary>
        /// <param name="eventSenderHubConnectionsCache"></param>
        /// <param name="logger"></param>
        public ProtocolEventSenderHub(
            IProtocolEventSenderHubConnectionsCache eventSenderHubConnectionsCache,
            ILogger<ProtocolEventSenderHub> logger)
            : base(eventSenderHubConnectionsCache, logger)
        {
        }
    }
}
