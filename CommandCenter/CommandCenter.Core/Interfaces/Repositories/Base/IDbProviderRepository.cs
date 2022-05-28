using CommandCenter.Core.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommandCenter.Core.Interfaces.Repositories.Base
{
    public interface IDbProviderRepository<T>
        where T : class, IBaseEntity
    {
        Task<string> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
