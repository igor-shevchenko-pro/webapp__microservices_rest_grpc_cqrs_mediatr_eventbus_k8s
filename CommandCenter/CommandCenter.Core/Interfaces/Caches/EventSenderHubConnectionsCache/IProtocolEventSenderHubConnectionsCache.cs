using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.EventSenderHubs.Base;
using CommandCenter.Core.Resources;

namespace CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache
{
    public interface IProtocolEventSenderHubConnectionsCache : IBaseEventSenderHubConnectionsCache<IBaseEventSenderHub<ProtocolGetResource>, ProtocolGetResource>
    {
    }
}
