using DistributionCenter.Core.Interfaces.DataProviders;
using DistributionCenter.Core.Resources;
using DistributionCenter.DataProviders.Http.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace DistributionCenter.DataProviders.Http
{
    public class PlatformSyncDataProvider : BaseSyncDataProvider<PlatformGetResource>, IPlatformSyncDataProvider
    {
        public PlatformSyncDataProvider(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient)
        {
            var baseAddress = configuration["CommandCenter.API:BaseAddress"];

            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Platform");
        }
    }
}
