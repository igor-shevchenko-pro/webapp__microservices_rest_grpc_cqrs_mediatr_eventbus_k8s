using CommandCenter.Core.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs;
using CommandCenter.Core.Resources;
using Microsoft.Extensions.Logging;

namespace CommandCenter.Core.Caches.EventSenderHubConnectionsCache
{
    public class FrameworkEventSenderHubConnectionsCache : BaseEventSenderHubConnectionsCache<IFrameworkEventSenderHub, FrameworkGetResource>, IFrameworkEventSenderHubConnectionsCache
    {
        public FrameworkEventSenderHubConnectionsCache(ILogger<FrameworkEventSenderHubConnectionsCache> logger)
            : base(logger)
        {
        }
    }
}
