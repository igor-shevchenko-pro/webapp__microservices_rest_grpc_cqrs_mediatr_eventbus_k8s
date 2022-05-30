using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.Resources.Base;

namespace CommandCenter.BLL.CQRS.Commands.Base
{
    public class BaseUpdateCommand<TModelCreate> : IBaseUpdateCommand<TModelCreate>
        where TModelCreate : class, IBaseResource
    {
        public string Id { get; set; }
        public TModelCreate Model { get; set; }

        public BaseUpdateCommand(string id, TModelCreate model)
        {
            Id = id;
            Model = model;
        }
    }
}
