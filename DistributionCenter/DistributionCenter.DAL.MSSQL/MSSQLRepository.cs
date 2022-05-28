using Microsoft.EntityFrameworkCore;
using DistributionCenter.Core.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DistributionCenter.Core.Interfaces.Entities.Base;

namespace DistributionCenter.DAL.MSSQL
{
    public sealed class MSSQLRepository<T> : IDbProviderRepository<T>
        where T : class, IBaseEntity
    {
        private readonly AppDbMSSQLContext _appDbContext;
        private DbSet<T> _entities { get; set; }

        public MSSQLRepository(AppDbMSSQLContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<T>();
        }

        public async Task<string> CreateAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _entities.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.FromResult(_entities.Where(predicate));
        }
    }
}
