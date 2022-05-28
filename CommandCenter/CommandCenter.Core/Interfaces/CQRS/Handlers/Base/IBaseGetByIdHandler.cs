using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Handlers.Base
{
    public interface IBaseGetByIdHandler<TEntity, TModelGet> : IRequestHandler<IBaseGetByIdQuery<TModelGet>, TModelGet>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
    }
}
