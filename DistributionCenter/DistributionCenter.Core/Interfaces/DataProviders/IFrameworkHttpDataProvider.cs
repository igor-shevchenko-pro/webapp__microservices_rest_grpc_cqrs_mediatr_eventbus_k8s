using DistributionCenter.Core.Interfaces.DataProviders.Base;
using DistributionCenter.Core.Resources;

namespace DistributionCenter.Core.Interfaces.DataProviders
{
    public interface IFrameworkHttpDataProvider : IBaseHttpDataProvider<FrameworkCreateResource, FrameworkGetResource>
    {
    }
}
