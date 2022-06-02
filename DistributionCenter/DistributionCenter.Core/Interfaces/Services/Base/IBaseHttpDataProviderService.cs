using DistributionCenter.Core.Interfaces.Resources.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionCenter.Core.Interfaces.Services.Base
{
    public interface IBaseHttpDataProviderService<TModelCreate, TModelGet>
        where TModelCreate : class, IBaseResource
        where TModelGet : class, IBaseResource
    {
        Task<string> CreateAsync(TModelCreate resource);
        Task UpdateAsync(string id, TModelCreate resource);
        Task RemoveAsync(string id);
        Task<TModelGet> GetAsync(string id);
        Task<IEnumerable<TModelGet>> GetAllAsync();
    }
}
