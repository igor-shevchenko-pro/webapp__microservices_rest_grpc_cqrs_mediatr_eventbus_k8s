using DistributionCenter.Core.Interfaces.Repositories.Base;
using DistributionCenter.Core.Interfaces.Resources.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionCenter.Core.Interfaces.Services.Base
{
    public interface IBaseService<TModelCreate, TModelGet, TEntity>
        where TModelCreate : class, IBaseResource
        where TModelGet : class, IBaseResource
        where TEntity : class, IBaseEntity, new()
    {
        Task<string> CreateAsync(TModelCreate model);
        Task UpdateAsync(string id, TModelCreate model);
        Task RemoveAsync(string id);
        Task<TModelGet> GetAsync(string id);
        Task<IEnumerable<TModelGet>> GetAllAsync();
    }
}
