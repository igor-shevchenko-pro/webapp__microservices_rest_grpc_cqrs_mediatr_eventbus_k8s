using System.Collections.Generic;

namespace CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base
{
    public interface IEventSenderHubClient
    {
        string Id { get; set; }
        IEnumerable<string> ConnectionIds { get; set; }
    }
}
