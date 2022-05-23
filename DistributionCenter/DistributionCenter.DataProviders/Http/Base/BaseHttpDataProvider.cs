using DistributionCenter.Core.Interfaces.DataProviders.Base;
using DistributionCenter.Core.Models.Exceptions;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DistributionCenter.DataProviders.Http.Base
{
    public abstract class BaseHttpDataProvider<T> : IBaseHttpDataProvider<T>
        where T : class
    {
        protected HttpClient HttpClient { get; set; }

        public BaseHttpDataProvider(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public virtual async Task PostAsync(T resource)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, HttpClient.DefaultRequestHeaders.Accept.ToString());
            var httpResponse = await HttpClient.PostAsync(HttpClient.BaseAddress, httpContent);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {HttpClient.BaseAddress}", httpResponse.StatusCode);
            }
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            var httpResponse = await HttpClient.GetAsync(HttpClient.BaseAddress);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {HttpClient.BaseAddress}", httpResponse.StatusCode);
            }

            return null;
        }
    }
}
