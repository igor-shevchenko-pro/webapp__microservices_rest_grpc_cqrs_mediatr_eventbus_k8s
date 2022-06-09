using CommandCenter.Core.Interfaces.Resources.Base;
using System.Threading.Tasks;

namespace CommandCenter.Core.Interfaces.EventSenderHubs.Base
{
    public interface IBaseEventSenderHub<TModelGet>
        where TModelGet : class, IBaseResource
    {
        Task BroadcastMessageAsync(TModelGet model);
    }
}
