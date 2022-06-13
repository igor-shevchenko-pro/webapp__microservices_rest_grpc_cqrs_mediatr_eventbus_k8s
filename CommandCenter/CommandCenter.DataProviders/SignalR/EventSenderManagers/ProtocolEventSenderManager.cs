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
    /// SignalR ProtocolEventSenderManager
    /// </summary>
    public class ProtocolEventSenderManager : BaseEventSenderManager<ProtocolGetResource>, IProtocolEventSenderManager
    {
        /// <summary>
        /// Constructor of ProtocolEventSenderManager
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="eventSenderHubConnectionsCache"></param>
        /// <param name="logger"></param>
        public ProtocolEventSenderManager(
            IConfiguration configuration,
            IHubContext<ProtocolEventSenderHub> hubContext,
            IProtocolEventSenderHubConnectionsCache eventSenderHubConnectionsCache,
            ILogger<ProtocolEventSenderManager> logger)
            : base(configuration, (IHubContext<BaseEventSenderHub<ProtocolGetResource>>)hubContext, eventSenderHubConnectionsCache, logger)
        {
        }
    }
}
