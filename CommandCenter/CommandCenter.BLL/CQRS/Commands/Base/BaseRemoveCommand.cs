using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.Resources.Base;

namespace CommandCenter.BLL.CQRS.Commands.Base
{
    public class BaseRemoveCommand<TModelBase> : IBaseRemoveCommand<TModelBase>
        where TModelBase : class, IBaseResource
    {
        public string Id { get; }

        public BaseRemoveCommand(string id)
        {
            Id = id;
        }
    }
}
