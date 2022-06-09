using CommandCenter.Core.Extensions;
using CommandCenter.Core.Interfaces.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CommandCenter.DataProviders.SignalR.EventSenderHubs.Base
{
    /// <summary>
    /// SignalR BaseEventSenderHub
    /// </summary>
    public abstract class BaseEventSenderHub<TModelGet> : Hub<BaseEventSenderHub<TModelGet>>, IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        protected readonly IConfiguration _configuration;
        protected readonly IHubContext<BaseEventSenderHub<TModelGet>> _hubContext;
        protected readonly ILogger<BaseEventSenderHub<TModelGet>> _logger;
        protected readonly string _hubMethod;

        /// <summary>
        /// Constructor of BaseEventSenderHub
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="logger"></param>
        public BaseEventSenderHub(
            IConfiguration configuration,
            IHubContext<BaseEventSenderHub<TModelGet>> hubContext,
            ILogger<BaseEventSenderHub<TModelGet>> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
            _hubMethod = configuration[$"SocketAPI:ProtocolGetResource:Method"];

            _logger.LogInformation($"{typeof(BaseEventSenderHub<TModelGet>)} initialized with method: {_hubMethod}");
        }

        public virtual async Task BroadcastMessageAsync(TModelGet model)
        {
            await _hubContext.Clients.All.SendAsync(_hubMethod, model);
            _logger.LogInformation($"{typeof(BaseEventSenderHub<TModelGet>)} hub sent message type of {typeof(TModelGet)} to all clients. Body: {model.ToJson()}");
        }
    }
}
