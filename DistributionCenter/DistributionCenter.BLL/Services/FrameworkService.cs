using DistributionCenter.BLL.Services.Base;
using DistributionCenter.Core.Interfaces.DataProviders.Base;
using DistributionCenter.Core.Interfaces.Services;
using DistributionCenter.Core.Resources;

namespace DistributionCenter.BLL.Services
{
    public class FrameworkService : BaseHttpDataProviderService<FrameworkCreateResource, FrameworkGetResource>, IFrameworkService
    {
        public FrameworkService(IBaseHttpDataProvider<FrameworkCreateResource, FrameworkGetResource> httpDataProvider)
            : base(httpDataProvider)
        {
        }
    }
}
