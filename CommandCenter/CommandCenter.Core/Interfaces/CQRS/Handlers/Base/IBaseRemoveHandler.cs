using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Handlers.Base
{
    public interface IBaseRemoveHandler<TEntity, TModelBase> : IRequestHandler<IBaseRemoveCommand<TModelBase>, Unit>
        where TEntity : class, IBaseEntity, new()
        where TModelBase : class, IBaseResource
    {
    }
}
