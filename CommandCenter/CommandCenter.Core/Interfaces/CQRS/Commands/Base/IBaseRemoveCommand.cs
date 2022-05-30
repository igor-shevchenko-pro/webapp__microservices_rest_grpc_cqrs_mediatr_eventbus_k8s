using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Commands.Base
{
    public interface IBaseRemoveCommand<TModelBase> : IRequest<Unit>
        where TModelBase : class, IBaseResource
    {
        string Id { get; }
    }
}
