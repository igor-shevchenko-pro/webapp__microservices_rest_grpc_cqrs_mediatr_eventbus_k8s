using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.EventSenderHubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CommandCenter.BLL.EventSenderHubs
{
    /// <summary>
    /// SignalR ProtocolEventSenderHub
    /// </summary>
    public class ProtocolEventSenderHub : Hub, IProtocolEventSenderHub
    {
        private readonly string _hubMethod;
        private readonly IHubContext<ProtocolEventSenderHub> _hubContext;
        private readonly ILogger<ProtocolEventSenderHub> _logger;

        /// <summary>
        /// Constructor of ProtocolEventSenderHub
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="logger"></param>
        public ProtocolEventSenderHub(
            IConfiguration configuration,
            IHubContext<ProtocolEventSenderHub> hubContext,
            ILogger<ProtocolEventSenderHub> logger)
        {
            _hubMethod = configuration["SocketAPI:Protocol:Method"];
            _hubContext = hubContext;
            _logger = logger;
            _logger.LogInformation($"ProtocolEventSenderHub method is: {_hubMethod}");
        }

        public async Task UpdateGeneralStatusAsync(Protocol entity)
        {
            var model = entity.ToViewModel(); // <-----

            _logger.LogInformation($"Raise update of the ProtocolEntity: {model.ToJson()}"); // <---

            await _hubContext.Clients.All.SendAsync(_hubMethod, model);
        }
    }
}
