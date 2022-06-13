using CommandCenter.Core.Interfaces.Resources.Base;
using CommandCenter.Core.Models.EventSenderNotifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandCenter.Core.Interfaces.EventSenders.EventSenderManagers.Base
{
    public interface IBaseEventSenderManager<TModelGet>
        where TModelGet : class, IBaseResource
    {
        Task SendToClientAsync(EventSenderNotificationModel model);
        Task SendToClientAsync(IEnumerable<EventSenderNotificationModel> models);

        Task SendToAllClientsAsync(EventSenderNotificationModel model);
        Task SendToAllClientsAsync(IEnumerable<EventSenderNotificationModel> models);
    }
}
