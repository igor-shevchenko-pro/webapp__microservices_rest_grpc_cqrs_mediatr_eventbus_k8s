using DistributionCenter.Core.Interfaces.DataProviders.Base;
using DistributionCenter.Core.Interfaces.Resources.Base;
using DistributionCenter.Core.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DistributionCenter.DataProviders.Http.Base
{
    public abstract class BaseHttpDataProvider<TModelCreate, TModelGet> : IBaseHttpDataProvider<TModelCreate, TModelGet>
        where TModelCreate : class, IBaseResource
        where TModelGet : class, IBaseResource
    {
        protected HttpClient HttpClient { get; set; }

        public BaseHttpDataProvider(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public virtual async Task<string> CreateAsync(TModelCreate resource)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, HttpClient.DefaultRequestHeaders.Accept.ToString());

            try
            {
                var httpResponse = await HttpClient.PostAsync(HttpClient.BaseAddress, httpContent);
            }
            catch (Exception ex)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while connecting to {HttpClient.BaseAddress}", ex, HttpStatusCode.BadGateway);
            }

            //if (!httpResponse.IsSuccessStatusCode)
            //{
            //    throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {HttpClient.BaseAddress}", httpResponse.StatusCode);
            //}

            return null;
        }

        public virtual async Task UpdateAsync(string id, TModelCreate resource)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while connecting to {HttpClient.BaseAddress}", ex, HttpStatusCode.BadGateway);
            }
        }

        public virtual async Task RemoveAsync(string id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while connecting to {HttpClient.BaseAddress}", ex, HttpStatusCode.BadGateway);
            }
        }

        public virtual async Task<TModelGet> GetAsync(string id)
        {
            var httpResponse = default(HttpResponseMessage);
            var result = default(TModelGet);

            try
            {
                httpResponse = await HttpClient.GetAsync($"{HttpClient.BaseAddress}/{id}");
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {HttpClient.BaseAddress}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while connecting to {HttpClient.BaseAddress}/{id}", ex, HttpStatusCode.BadGateway);
            }

            using (var reponseStream = await httpResponse.Content.ReadAsStreamAsync())
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                result = await JsonSerializer.DeserializeAsync<TModelGet>(reponseStream, options);
            }

            return result;
        }

        public virtual async Task<IEnumerable<TModelGet>> GetAllAsync()
        {
            var httpResponse = default(HttpResponseMessage);
            var result = default(IEnumerable<TModelGet>);

            try
            {
                httpResponse = await HttpClient.GetAsync(HttpClient.BaseAddress);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {HttpClient.BaseAddress}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while connecting to {HttpClient.BaseAddress}", ex, HttpStatusCode.BadGateway);
            }

            using (var reponseStream = await httpResponse.Content.ReadAsStreamAsync())
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                result = await JsonSerializer.DeserializeAsync<IEnumerable<TModelGet>>(reponseStream, options);
            }

            return result;
        }
    }
}
