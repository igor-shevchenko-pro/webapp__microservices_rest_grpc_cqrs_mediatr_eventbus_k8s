using System.Collections.Generic;

namespace CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base
{
    public interface IEventSenderHubClient
    {
        string Id { get; set; }
        IList<string> ConnectionIds { get; set; }
    }
}
