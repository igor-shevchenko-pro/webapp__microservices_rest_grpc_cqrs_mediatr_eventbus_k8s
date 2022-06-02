using DistributionCenter.Core.Interfaces.DataProviders.Base;
using DistributionCenter.Core.Interfaces.Resources.Base;
using DistributionCenter.Core.Interfaces.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionCenter.BLL.Services.Base
{
    public abstract class BaseHttpDataProviderService<TModelCreate, TModelGet> : IBaseHttpDataProviderService<TModelCreate, TModelGet>
        where TModelCreate : class, IBaseResource
        where TModelGet : class, IBaseResource
    {
        protected readonly IBaseHttpDataProvider<TModelCreate, TModelGet> _httpDataProvider;

        public BaseHttpDataProviderService(IBaseHttpDataProvider<TModelCreate, TModelGet> httpDataProvider)
        {
            _httpDataProvider = httpDataProvider;
        }

        public virtual async Task<string> CreateAsync(TModelCreate resource)
        {
            return await _httpDataProvider.CreateAsync(resource);
        }

        public virtual async Task UpdateAsync(string id, TModelCreate resource)
        {
            await _httpDataProvider.UpdateAsync(id, resource);
        }

        public virtual async Task RemoveAsync(string id)
        {
            await _httpDataProvider.RemoveAsync(id);
        }

        public virtual async Task<TModelGet> GetAsync(string id)
        {
            return await _httpDataProvider.GetAsync(id);
        }

        public virtual async Task<IEnumerable<TModelGet>> GetAllAsync()
        {
            return await _httpDataProvider.GetAllAsync();
        }
    }
}
