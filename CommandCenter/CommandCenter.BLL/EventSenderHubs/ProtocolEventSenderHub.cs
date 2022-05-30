using CommandCenter.Core.Interfaces.EventSenderHubs;
using Microsoft.AspNetCore.SignalR;

namespace CommandCenter.BLL.EventSenderHubs
{
    public class ProtocolEventSenderHub : Hub, IProtocolEventSenderHub
    {
        public ProtocolEventSenderHub()
        {

        }
    }
}
