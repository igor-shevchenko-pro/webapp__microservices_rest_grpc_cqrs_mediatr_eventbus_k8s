using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;
using System.Collections.Generic;

namespace CommandCenter.Core.Interfaces.CQRS.Handlers.Base
{
    public interface IGetAllResourcesBaseHandler<TEntity, TModelGet> : IRequestHandler<IGetAllResourcesBaseQuery<TModelGet>, IEnumerable<TModelGet>>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
    }
}
