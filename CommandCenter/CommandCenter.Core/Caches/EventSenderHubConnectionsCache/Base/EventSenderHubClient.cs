using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using System.Collections.Generic;

namespace CommandCenter.Core.Caches.EventSenderHubConnectionsCache.Base
{
    public class EventSenderHubClient : IEventSenderHubClient
    {
        public string Id { get; set; } = default!;
        public IEnumerable<string> ConnectionIds { get; set; } = new List<string>();
    }
}
