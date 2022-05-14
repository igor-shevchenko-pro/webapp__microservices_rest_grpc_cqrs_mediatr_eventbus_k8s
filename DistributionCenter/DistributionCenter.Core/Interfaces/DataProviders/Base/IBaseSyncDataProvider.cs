using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionCenter.Core.Interfaces.DataProviders.Base
{
    public interface IBaseSyncDataProvider<T>
        where T : class
    {
        Task SendDataToAsync(T resource);
        Task<T> GetDataFromAsync(string id);
        Task<IEnumerable<T>> GetDataFromAsync();
    }
}
