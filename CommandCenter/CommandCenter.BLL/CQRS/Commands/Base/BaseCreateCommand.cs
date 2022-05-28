using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.Resources.Base;

namespace CommandCenter.BLL.CQRS.Commands.Base
{
    public class BaseCreateCommand<TModelCreate> : IBaseCreateCommand<TModelCreate>
        where TModelCreate : class, IBaseResource
    {
        public TModelCreate Model { get; set; }

        public BaseCreateCommand(TModelCreate model)
        {
            Model = model;
        }
    }
}
