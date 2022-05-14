using DistributionCenter.Core.Interfaces.DataProviders.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DistributionCenter.DataProviders.Http.Base
{
    public abstract class BaseSyncDataProvider<T> : IBaseSyncDataProvider<T>
        where T : class
    {
        protected HttpClient HttpClient { get; set; }

        public BaseSyncDataProvider(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public virtual async Task SendDataToAsync(T resource)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            //var response = await HttpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("--> Sync POST to CommandService was OK!");
            //}
            //else
            //{
            //    Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
            //}
        }

        public virtual async Task<T> GetDataFromAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetDataFromAsync()
        {
            throw new NotImplementedException();
        }
    }
}
