using CommandCenter.BLL.EventSenderHubs;
using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderManagers;
using CommandCenter.Core.Resources;
using CommandCenter.DataProviders.SignalR.EventSenderHubs.Base;
using CommandCenter.DataProviders.SignalR.EventSenderManagers.Base;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CommandCenter.DataProviders.SignalR.EventSenderManagers
{
    /// <summary>
    /// SignalR FrameworkEventSenderManager
    /// </summary>
    public class FrameworkEventSenderManager : BaseEventSenderManager<FrameworkGetResource>, IFrameworkEventSenderManager
    {
        /// <summary>
        /// Constructor of FrameworkEventSenderManager
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="eventSenderHubConnectionsCache"></param>
        /// <param name="logger"></param>
        public FrameworkEventSenderManager(
            IConfiguration configuration,
            IHubContext<BaseEventSenderHub<FrameworkGetResource>> hubContext,
            IFrameworkEventSenderHubConnectionsCache eventSenderHubConnectionsCache,
            ILogger<FrameworkEventSenderManager> logger)
            : base(configuration, hubContext, eventSenderHubConnectionsCache, logger)
        {
        }
    }
}
