using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache;
using CommandCenter.Core.Interfaces.EventSenderHubs;
using CommandCenter.Core.Resources;
using CommandCenter.DataProviders.SignalR.EventSenderHubs.Base;
using Microsoft.Extensions.Configuration;
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
        /// <param name="configuration"></param>
        /// <param name="eventSenderHubConnectionsCache"></param>
        /// <param name="logger"></param>
        public FrameworkEventSenderHub(
            IConfiguration configuration,
            IFrameworkEventSenderHubConnectionsCache eventSenderHubConnectionsCache,
            ILogger<FrameworkEventSenderHub> logger)
            : base(configuration, eventSenderHubConnectionsCache, logger)
        {
        }
    }
}
