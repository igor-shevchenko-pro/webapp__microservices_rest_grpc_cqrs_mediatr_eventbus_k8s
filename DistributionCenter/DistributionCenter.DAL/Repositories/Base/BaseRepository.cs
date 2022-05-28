using DistributionCenter.Core.Interfaces.Entities.Base;
using DistributionCenter.Core.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DistributionCenter.DAL.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class, IBaseEntity
    {
        protected readonly IDbProviderRepository<T> _repository;

        public BaseRepository(IDbProviderRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<string> CreateAsync(T entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            entity.Updated = DateTime.UtcNow;
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task RemoveAsync(T entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public virtual async Task<T> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }
    }
}
