using CommandCenter.Core.Interfaces.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base
{
    public interface IBaseEventSenderHubConnectionsCache<THub, TModelGet>
        where THub : class, IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        Task AddClientAsync(string id, string connectionId);
        Task<IEventSenderHubClient> GetClientByIdAsync(string id);
        Task<IEnumerable<IEventSenderHubClient>> GetClientsByIdsAsync(IEnumerable<string> ids);
        Task<IEventSenderHubClient> GetClientByConnectionIdAsync(string connectionId);
        Task<IEnumerable<IEventSenderHubClient>> GetAllClientsAsync();
        Task RemoveClientAsync(string id);

        Task AddConnectionAsync(string connectionId, string clientId);
        Task<IEnumerable<string>> GetConnectionIdsByClientIdsAsync(params string[] ids);
        Task<IEnumerable<string>> GetAllConnectionsAsync();
        Task RemoveConnectionAsync(string connectionId, string clientId);
    }
}
