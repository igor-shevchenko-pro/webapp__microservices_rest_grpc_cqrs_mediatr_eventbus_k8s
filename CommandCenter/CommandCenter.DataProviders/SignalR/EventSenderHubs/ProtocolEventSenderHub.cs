using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.EventSenderHubs;
using CommandCenter.Core.Resources;
using CommandCenter.DataProviders.SignalR.EventSenderHubs.Base;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.EventSenderHubs
{
    /// <summary>
    /// SignalR ProtocolEventSenderHub
    /// </summary>
    public class ProtocolEventSenderHub : BaseEventSenderHub<ProtocolGetResource>, IProtocolEventSenderHub
    {
        /// <summary>
        /// Constructor of ProtocolEventSenderHub
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hubContext"></param>
        /// <param name="logger"></param>
        public ProtocolEventSenderHub(
            IConfiguration configuration,
            IHubContext<BaseEventSenderHub<ProtocolGetResource>> hubContext,
            ILogger<ProtocolEventSenderHub> logger)
            : base(configuration, hubContext, logger)
        {
        }
    }
}
