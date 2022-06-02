using DistributionCenter.BLL.Services.Base;
using DistributionCenter.Core.Interfaces.DataProviders;
using DistributionCenter.Core.Interfaces.Services;
using DistributionCenter.Core.Resources;

namespace DistributionCenter.BLL.Services
{
    public class FrameworkService : BaseHttpDataProviderService<FrameworkCreateResource, FrameworkGetResource>, IFrameworkService
    {
        public FrameworkService(IFrameworkHttpDataProvider httpDataProvider)
            : base(httpDataProvider)
        {
        }
    }
}
