using DistributionCenter.Core;
using DistributionCenter.Core.Interfaces.DataProviders.Base;
using DistributionCenter.Core.Interfaces.Resources.Base;
using DistributionCenter.Core.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DistributionCenter.DataProviders.Http.Base
{
    public abstract class BaseHttpDataProvider<TModelCreate, TModelGet> : IBaseHttpDataProvider<TModelCreate, TModelGet>
        where TModelCreate : class, IBaseResource
        where TModelGet : class, IBaseResource
    {
        protected HttpClient HttpClient { get; set; }
        protected virtual JsonSerializerOptions JsonSerializerOptions { get; set; }

        public BaseHttpDataProvider(HttpClient httpClient)
        {
            HttpClient = httpClient;
            JsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };
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

            try
            {
                httpResponse = await HttpClient.GetAsync($"{HttpClient.BaseAddress}/{id}");
            }
            catch (Exception ex)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while connecting to {HttpClient.BaseAddress}/{id}", ex, HttpStatusCode.BadGateway);
            }

            return await HandleHttpResponseAsync<TModelGet>(HttpClient, httpResponse);
        }

        public virtual async Task<IEnumerable<TModelGet>> GetAllAsync()
        {
            var httpResponse = default(HttpResponseMessage);

            try
            {
                httpResponse = await HttpClient.GetAsync(HttpClient.BaseAddress);
            }
            catch (Exception ex)
            {
                throw new HttpDataProviderException($"HttpDataProviderException occurred while connecting to {HttpClient.BaseAddress}", ex, HttpStatusCode.BadGateway);
            }

            return await HandleHttpResponseAsync<IEnumerable<TModelGet>>(HttpClient, httpResponse);
        }

        protected virtual async Task<T> HandleHttpResponseAsync<T>(HttpClient httpClient, HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions = null)
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                var supportedVersionsList = httpResponse.Headers.GetValues(Constants.HttpContextHeaderKeys.API_SUPPORTED_VERSIONS);
                var supportedVersions = supportedVersionsList.FirstOrDefault().Split(", ");
                var specifiedVersion = httpClient.DefaultRequestVersion.ToString();

                if (!supportedVersions.Contains(specifiedVersion))
                {
                    throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {httpClient.BaseAddress}",
                        new UnsupportedApiVersionException($"UnsupportedApiVersionException occurred while connecting to {httpClient.BaseAddress} with apiVersion: {specifiedVersion}"),
                        HttpStatusCode.HttpVersionNotSupported);
                }
                else
                {
                    throw new HttpDataProviderException($"HttpDataProviderException occurred while operating with {httpClient.BaseAddress}");
                }
            }

            return await DeserializeResponseAsync<T>(httpResponse, jsonSerializerOptions);
        }

        protected virtual async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions = null)
        {
            var result = default(T);

            using (var reponseStream = await httpResponse.Content.ReadAsStreamAsync())
            {
                result = await JsonSerializer.DeserializeAsync<T>(reponseStream, jsonSerializerOptions ?? JsonSerializerOptions);
            }

            return result;
        }
    }
}
