using CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using System.Collections.Generic;

namespace CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base
{
    public interface IBaseEventSenderHubConnectionsCache<THub, TModelGet>
        where THub : class, IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        void AddClient(string id, string connectionId);
        IEventSenderHubClient GetClientById(string id);
        IEnumerable<IEventSenderHubClient> GetClientsByIds(IEnumerable<string> ids);
        IEventSenderHubClient GetClientByConnectionId(string connectionId);
        IEnumerable<IEventSenderHubClient> GetAllClients();
        void RemoveClient(string id);

        void AddConnection(string connectionId, string clientId);
        IEnumerable<string> GetConnectionIdsByClientIds(params string[] ids);
        IEnumerable<string> GetAllConnections();
        void RemoveConnection(string connectionId, string clientId);
    }
}
