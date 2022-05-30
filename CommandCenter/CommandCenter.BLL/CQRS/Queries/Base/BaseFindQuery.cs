using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using System;
using System.Linq.Expressions;

namespace CommandCenter.BLL.CQRS.Queries.Base
{
    public class BaseFindQuery<TEntity, TModelGet> : IBaseFindQuery<TEntity, TModelGet>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
        public Expression<Func<TEntity, bool>> Predicate { get; }

        public BaseFindQuery(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
}
