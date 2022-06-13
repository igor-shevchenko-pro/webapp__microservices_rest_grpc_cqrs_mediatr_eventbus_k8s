using CommandCenter.Core.Interfaces.Resources.Base;
using System;
using System.Threading.Tasks;

namespace CommandCenter.Core.Interfaces.EventSenders.EventSenderHubs.Base
{
    public interface IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        Task OnConnectedAsync();
        Task OnDisconnectedAsync(Exception exception);
    }
}
