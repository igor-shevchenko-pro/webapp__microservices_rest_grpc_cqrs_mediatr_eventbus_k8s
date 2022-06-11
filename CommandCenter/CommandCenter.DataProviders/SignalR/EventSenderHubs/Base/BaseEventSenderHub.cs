using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CommandCenter.DataProviders.SignalR.EventSenderHubs.Base
{
    /// <summary>
    /// SignalR BaseEventSenderHub
    /// </summary>
    public abstract class BaseEventSenderHub<TModelGet> : Hub, IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        protected readonly string _hubMethod;
        protected readonly IConfiguration _configuration;
        protected readonly IBaseEventSenderHubConnectionsCache<IBaseEventSenderHub<TModelGet>, TModelGet> _eventSenderHubConnectionsCache;
        protected readonly ILogger<BaseEventSenderHub<TModelGet>> _logger;

        /// <summary>
        /// Constructor of BaseEventSenderHub
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="eventSenderHubConnectionsCache"></param>
        /// <param name="logger"></param>
        public BaseEventSenderHub(
            IConfiguration configuration,
            IBaseEventSenderHubConnectionsCache<IBaseEventSenderHub<TModelGet>, TModelGet> eventSenderHubConnectionsCache,
            ILogger<BaseEventSenderHub<TModelGet>> logger)
        {
            _hubMethod = configuration[$"SocketAPI:{typeof(TModelGet)}:Method"];
            _eventSenderHubConnectionsCache = eventSenderHubConnectionsCache;
            _logger = logger;

            _logger.LogInformation($"{typeof(BaseEventSenderHub<TModelGet>)} created with method: {_hubMethod}");
        }

        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var userId = GetUserId();
            _eventSenderHubConnectionsCache.AddConnection(userId, connectionId);

            _logger.LogInformation($"New SignalR connection created. UserId: {userId} ConnectionId: {connectionId}");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var userId = GetUserId();
            if (connectionId != null)
            {
                _eventSenderHubConnectionsCache.RemoveConnection(connectionId, userId);
            }

            await base.OnDisconnectedAsync(exception);

            _logger.LogInformation($"SignalR connection removed. UserId: {userId} ConnectionId: {connectionId}");
        }

        protected string GetUserId()
        {
            return this.Context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        //public virtual async Task BroadcastMessageAsync(TModelGet model)
        //{
        //    await _hubContext.Clients.All.SendAsync(_hubMethod, model);
        //    _logger.LogInformation($"{typeof(BaseEventSenderHub<TModelGet>)} hub sent message type of {typeof(TModelGet)} to all clients. Body: {model.ToJson()}");
        //}
    }
}
