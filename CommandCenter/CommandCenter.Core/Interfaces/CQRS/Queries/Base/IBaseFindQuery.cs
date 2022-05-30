using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CommandCenter.Core.Interfaces.CQRS.Queries.Base
{
    public interface IBaseFindQuery<TEntity, TModelGet> : IRequest<IEnumerable<TModelGet>>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
    }
}
