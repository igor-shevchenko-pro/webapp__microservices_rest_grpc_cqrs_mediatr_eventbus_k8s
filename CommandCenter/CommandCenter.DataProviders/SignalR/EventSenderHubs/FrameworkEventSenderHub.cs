using CommandCenter.Core.Interfaces.EventSenderHubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.EventSenderHubs
{
    /// <summary>
    /// SignalR FrameworkEventSenderHub
    /// </summary>
    public class FrameworkEventSenderHub : Hub, IFrameworkEventSenderHub
    {
        private readonly string _hubMethod;
        private readonly IHubContext<FrameworkEventSenderHub> _hubContext;
        private readonly ILogger<FrameworkEventSenderHub> _logger;

        /// <summary>
        /// Constructor of FrameworkEventSenderHub
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="logger"></param>
        public FrameworkEventSenderHub(
            IConfiguration configuration,
            IHubContext<FrameworkEventSenderHub> hubContext,
            ILogger<FrameworkEventSenderHub> logger)
        {
            _hubMethod = configuration["SocketAPI:Framework:Method"];
            _hubContext = hubContext;
            _logger = logger;
        }
    }
}
