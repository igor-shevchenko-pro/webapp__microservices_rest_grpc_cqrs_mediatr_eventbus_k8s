using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Commands.Base
{
    public interface IBaseUpdateCommand<TModelCreate> : IRequest<Unit>
        where TModelCreate : class, IBaseResource
    {
        string Id { get; set; }
        TModelCreate Model { get; set; }
    }
}
