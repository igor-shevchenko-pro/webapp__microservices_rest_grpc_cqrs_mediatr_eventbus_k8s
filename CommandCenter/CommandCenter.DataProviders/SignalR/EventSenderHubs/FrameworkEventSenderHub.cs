using CommandCenter.Core.Interfaces.EventSenderHubs;
using CommandCenter.Core.Resources;
using CommandCenter.DataProviders.SignalR.EventSenderHubs.Base;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.EventSenderHubs
{
    /// <summary>
    /// SignalR FrameworkEventSenderHub
    /// </summary>
    public class FrameworkEventSenderHub : BaseEventSenderHub<FrameworkGetResource>, IFrameworkEventSenderHub
    {
        /// <summary>
        /// Constructor of FrameworkEventSenderHub
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="logger"></param>
        public FrameworkEventSenderHub(
            IConfiguration configuration,
            IHubContext<BaseEventSenderHub<FrameworkGetResource>> hubContext,
            ILogger<FrameworkEventSenderHub> logger)
            : base(configuration, hubContext, logger)
        {
        }
    }
}
