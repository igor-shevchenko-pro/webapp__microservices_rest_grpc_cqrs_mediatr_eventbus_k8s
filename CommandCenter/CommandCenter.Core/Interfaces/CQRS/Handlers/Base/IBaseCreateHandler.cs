using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Handlers.Base
{
    public interface IBaseCreateHandler<TEntity, TModelCreate, TModelGet> : IRequestHandler<IBaseCreateCommand<TModelCreate>, string>
        where TEntity : class, IBaseEntity, new()
        where TModelCreate : class, IBaseResource
        where TModelGet : class, IBaseResource
    {
    }
}
