using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Handlers.Base
{
    public interface IBaseUpdateHandler<TEntity, TModelCreate> : IRequestHandler<IBaseUpdateCommand<TModelCreate>, Unit>
        where TEntity : class, IBaseEntity, new()
        where TModelCreate : class, IBaseResource
    {
    }
}
