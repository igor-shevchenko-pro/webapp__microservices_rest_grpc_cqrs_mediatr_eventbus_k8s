using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandCenter.Core.Caches.EventSenderHubConnectionsCache.Base
{
    public abstract class BaseEventSenderHubConnectionsCache<THub, TModelGet> : IBaseEventSenderHubConnectionsCache<THub, TModelGet>
        where THub : class, IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        protected readonly object _clientLocker;
        protected IList<IEventSenderHubClient> _hubClients;
        protected readonly ILogger<BaseEventSenderHubConnectionsCache<THub, TModelGet>> _logger;

        public BaseEventSenderHubConnectionsCache(ILogger<BaseEventSenderHubConnectionsCache<THub, TModelGet>> logger)
        {
            _clientLocker = new object();
            _hubClients = new List<IEventSenderHubClient>();
            _logger = logger;

            _logger.LogInformation($"{typeof(BaseEventSenderHubConnectionsCache<THub, TModelGet>)} created successfully.");
        }

        public virtual void AddClient(string id, string connectionId)
        {
            lock (_clientLocker)
            {
                var client = _hubClients.FirstOrDefault(x => x.Id == id);
                if (client == null)
                {
                    client = new EventSenderHubClient()
                    {
                        Id = id,
                        ConnectionIds = new List<string> { connectionId }
                    };
                    _hubClients.Add(client);
                }
            }
        }

        public virtual IEventSenderHubClient GetClientById(string id)
        {
            lock (_clientLocker)
            {
                return _hubClients.FirstOrDefault(x => x.Id == id);
            }
        }

        public virtual IEnumerable<IEventSenderHubClient> GetClientsByIds(IEnumerable<string> ids)
        {
            lock (_clientLocker)
            {
                return _hubClients.Where(x => ids.Contains(x.Id));
            }
        }

        public virtual IEventSenderHubClient GetClientByConnectionId(string connectionId)
        {
            lock (_clientLocker)
            {
                return _hubClients.FirstOrDefault(x => x.ConnectionIds.Any(x => x == connectionId));
            }
        }

        public virtual IEnumerable<IEventSenderHubClient> GetAllClients()
        {
            lock (_clientLocker)
            {
                return _hubClients.ToList();
            }
        }

        public virtual void RemoveClient(string id)
        {
            lock (_clientLocker)
            {
                var client = _hubClients.FirstOrDefault(x => x.Id == id);
                if(client != null)
                {
                    _hubClients.Remove(client);
                }
            }
        }


        public virtual void AddConnection(string connectionId, string clientId)
        {
            lock (_clientLocker)
            {
                var client = _hubClients.FirstOrDefault(x => x.Id == clientId && !x.ConnectionIds.Contains(connectionId));
                if (client != null)
                {
                    client.ConnectionIds.Add(connectionId);
                }
            }
        }

        public virtual IEnumerable<string> GetConnectionIdsByClientIds(params string[] ids)
        {
            lock (_clientLocker)
            {
                var clients = _hubClients.Where(x => ids.Contains(x.Id));
                return clients.SelectMany(x => x.ConnectionIds);
            }
        }

        public virtual IEnumerable<string> GetAllConnections()
        {
            lock (_clientLocker)
            {
                return _hubClients.SelectMany(x => x.ConnectionIds);
            }
        }

        public virtual void RemoveConnection(string connectionId, string clientId)
        {
            lock (_clientLocker)
            {
                var client = _hubClients.FirstOrDefault(x => x.ConnectionIds.Any(y => y == connectionId));
                if (client != null)
                {
                    client.ConnectionIds.Remove(connectionId);
                }
            }
        }
    }
}
