﻿using DistributionCenter.Core.Interfaces.DataProviders.Base;
using DistributionCenter.Core.Interfaces.Resources.Base;
using DistributionCenter.Core.Models.Exceptions;
using System.Collections.Generic;
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
            var httpResponse = await HttpClient.PostAsync(HttpClient.BaseAddress, httpContent);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {HttpClient.BaseAddress}", httpResponse.StatusCode);
            }

            return null;
        }

        public virtual async Task UpdateAsync(string id, TModelCreate resource)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task RemoveAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<TModelGet> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<IEnumerable<TModelGet>> GetAllAsync()
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
