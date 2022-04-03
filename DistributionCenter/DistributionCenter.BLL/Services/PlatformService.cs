using DistributionCenter.BLL.Services.Base;
using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Interfaces.Profiles.MapperProfiles;
using DistributionCenter.Core.Interfaces.Repositories;
using DistributionCenter.Core.Interfaces.Services;
using DistributionCenter.Core.Resources;

namespace DistributionCenter.BLL.Services
{
    public class PlatformService : BaseService<PlatformCreateResource, PlatformGetResource, Platform>, IPlatformService
    {
        public PlatformService(IPlatformRepository repository, IDataMapper dataMapper) 
            : base(repository, dataMapper)
        {
        }
    }
}
