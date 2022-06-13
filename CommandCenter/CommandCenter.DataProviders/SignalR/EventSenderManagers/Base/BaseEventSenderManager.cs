using CommandCenter.Core.Extensions;
using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderManagers.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using CommandCenter.Core.Models.EventSenderNotifications;
using CommandCenter.DataProviders.SignalR.EventSenderHubs.Base;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandCenter.DataProviders.SignalR.EventSenderManagers.Base
{
    /// <summary>
    /// SignalR BaseEventSenderManager
    /// </summary>
    /// <typeparam name="TModelGet"></typeparam>
    public abstract class BaseEventSenderManager<TModelGet> : IBaseEventSenderManager<TModelGet>
        where TModelGet : class, IBaseResource
    {
        protected readonly string _hubMethod;
        protected readonly IConfiguration _configuration;
        protected readonly IHubContext<BaseEventSenderHub<TModelGet>> _hubContext;
        protected readonly IBaseEventSenderHubConnectionsCache<IBaseEventSenderHub<TModelGet>, TModelGet> _eventSenderHubConnectionsCache;
        protected readonly ILogger<BaseEventSenderManager<TModelGet>> _logger;

        /// <summary>
        /// Constructor of BaseEventSenderManager
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="eventSenderHubConnectionsCache"></param>
        /// <param name="logger"></param>
        public BaseEventSenderManager(
            IConfiguration configuration,
            IHubContext<BaseEventSenderHub<TModelGet>> hubContext,
            IBaseEventSenderHubConnectionsCache<IBaseEventSenderHub<TModelGet>, TModelGet> eventSenderHubConnectionsCache,
            ILogger<BaseEventSenderManager<TModelGet>> logger)
        {
            _hubMethod = configuration[$"SocketAPI:{typeof(TModelGet)}:Method"];
            _hubContext = hubContext;
            _eventSenderHubConnectionsCache = eventSenderHubConnectionsCache;
            _logger = logger;
        }

        public virtual async Task SendToClientAsync(EventSenderNotificationModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
                var client = _eventSenderHubConnectionsCache.GetClientById(model.ToUserId);
                if (client == null) 
                {
                    _logger.LogWarning($"User with id: {model.ToUserId} doesn't have active signalR connecion.");
                    return;
                } 

                foreach (string connection in client.ConnectionIds)
                {
                    await _hubContext.Clients.Client(connection).SendAsync(_hubMethod, model);
                    _logger.LogInformation($"{typeof(BaseEventSenderManager<TModelGet>)} manager sent message type of {typeof(TModelGet)} to client: {client.Id}, connectionId: {connection}. Body: {model.ToJson()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred while sending signalR notification.", ex);
            }
        }

        public virtual async Task SendToClientAsync(IEnumerable<EventSenderNotificationModel> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            try
            {
                foreach (var notification in models)
                {
                    var client = _eventSenderHubConnectionsCache.GetClientById(notification.ToUserId);
                    if (client == null)
                    {
                        _logger.LogWarning($"User with id: {notification.ToUserId} doesn't have active signalR connecion.");
                        return;
                    }

                    foreach (var connection in client.ConnectionIds)
                    {
                        await _hubContext.Clients.Client(connection).SendAsync(_hubMethod, notification);
                        _logger.LogInformation($"{typeof(BaseEventSenderManager<TModelGet>)} manager sent message type of {typeof(TModelGet)} to client: {client.Id}, connectionId: {connection}. Body: {notification.ToJson()}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred while sending signalR notification.", ex);
            }
        }

        public virtual async Task SendToAllClientsAsync(EventSenderNotificationModel model)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync(_hubMethod, model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred while sending signalR notification.", ex);
            }
        }

        public virtual async Task SendToAllClientsAsync(IEnumerable<EventSenderNotificationModel> models)
        {
            try
            {
                foreach (var notification in models)
                {
                    await _hubContext.Clients.All.SendAsync(_hubMethod, notification);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred while sending signalR notification.", ex);
            }
        }
    }
}
