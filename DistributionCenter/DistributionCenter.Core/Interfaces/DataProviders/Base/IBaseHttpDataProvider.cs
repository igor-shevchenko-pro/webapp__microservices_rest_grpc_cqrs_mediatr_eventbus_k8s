using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionCenter.Core.Interfaces.DataProviders.Base
{
    public interface IBaseHttpDataProvider<T>
        where T : class
    {
        Task PostAsync(T resource);
        Task<IEnumerable<T>> GetAsync();
    }
}
