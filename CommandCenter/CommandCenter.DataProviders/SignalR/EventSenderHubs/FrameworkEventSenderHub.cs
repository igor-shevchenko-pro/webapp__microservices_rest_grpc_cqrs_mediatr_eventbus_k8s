using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs;
using CommandCenter.Core.Resources;
using CommandCenter.DataProviders.SignalR.EventSenderHubs.Base;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.EventSenderHubs
{
    /// <summary>
    /// SignalR FrameworkEventSenderHub
    /// </summary>
    public class FrameworkEventSenderHub : BaseEventSenderHub<FrameworkGetResource>, IFrameworkEventSenderHub
    {
        /// <summary>
        /// Constructor of FrameworkEventSenderHub
        /// </summary>
        /// <param name="eventSenderHubConnectionsCache"></param>
        /// <param name="logger"></param>
        public FrameworkEventSenderHub(
            IFrameworkEventSenderHubConnectionsCache eventSenderHubConnectionsCache,
            ILogger<FrameworkEventSenderHub> logger)
            : base(eventSenderHubConnectionsCache, logger)
        {
        }
    }
}
