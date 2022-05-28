using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Interfaces.Repositories;
using DistributionCenter.Core.Interfaces.Repositories.Base;
using DistributionCenter.DAL.Repositories.Base;

namespace DistributionCenter.DAL.Repositories
{
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(IDbProviderRepository<Platform> repository)
            : base(repository)
        {
        }
    }
}
