using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs.Base;
using CommandCenter.Core.Resources;

namespace CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache
{
    public interface IFrameworkEventSenderHubConnectionsCache : IBaseEventSenderHubConnectionsCache<IBaseEventSenderHub<FrameworkGetResource>, FrameworkGetResource>
    {
    }
}
