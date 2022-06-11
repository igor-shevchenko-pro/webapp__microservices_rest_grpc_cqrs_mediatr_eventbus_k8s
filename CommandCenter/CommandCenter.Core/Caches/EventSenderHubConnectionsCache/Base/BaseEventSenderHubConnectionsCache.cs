using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandCenter.Core.Caches.EventSenderHubConnectionsCache.Base
{
    public abstract class BaseEventSenderHubConnectionsCache<THub, TModelGet> : IBaseEventSenderHubConnectionsCache<THub, TModelGet>
        where THub : class, IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        protected readonly object _clientLocker = new object();
        protected readonly ILogger<BaseEventSenderHubConnectionsCache<THub, TModelGet>> _logger;
        protected IEnumerable<IEventSenderHubClient> _hubClients { get; }

        public BaseEventSenderHubConnectionsCache(ILogger<BaseEventSenderHubConnectionsCache<THub, TModelGet>> logger)
        {
            _hubClients = new List<IEventSenderHubClient>();
            _logger = logger;

            _logger.LogInformation($"{typeof(BaseEventSenderHubConnectionsCache<THub, TModelGet>)} created successfully.");
        }

        //~EventSenderHubConnectionCache()
        //{
        //    _logger.LogInformation($"{typeof(EventSenderHubConnectionCache<THub>)} destructed successfully.");
        //}

        public virtual async Task AddClientAsync(string id, string connectionId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEventSenderHubClient> GetClientByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<IEventSenderHubClient>> GetClientsByIdsAsync(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEventSenderHubClient> GetClientByConnectionIdAsync(string connectionId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<IEventSenderHubClient>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task RemoveClientAsync(string id)
        {
            throw new NotImplementedException();
        }


        public virtual async Task AddConnectionAsync(string connectionId, string clientId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<string>> GetConnectionIdsByClientIdsAsync(params string[] ids)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<string>> GetAllConnectionsAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task RemoveConnectionAsync(string connectionId, string clientId)
        {
            throw new NotImplementedException();
        }
    }
}
