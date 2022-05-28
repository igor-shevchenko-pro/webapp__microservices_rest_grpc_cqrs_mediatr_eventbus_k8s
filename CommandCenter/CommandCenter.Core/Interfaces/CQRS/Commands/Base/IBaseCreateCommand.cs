using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Commands.Base
{
    public interface IBaseCreateCommand<TModelCreate> : IRequest<string>
        where TModelCreate : class, IBaseResource
    {
        TModelCreate Model { get; set; }
    }
}
