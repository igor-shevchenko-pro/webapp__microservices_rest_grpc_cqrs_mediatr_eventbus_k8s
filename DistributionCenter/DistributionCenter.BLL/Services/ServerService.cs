using DistributionCenter.API.Resources;
using DistributionCenter.BLL.Services.Base;
using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Interfaces.Profiles.MapperProfiles;
using DistributionCenter.Core.Interfaces.Repositories;
using DistributionCenter.Core.Interfaces.Services;

namespace DistributionCenter.BLL.Services
{
    public class ServerService : BaseService<ServerCreateResource, ServerGetResource, Server>, IServerService
    {
        public ServerService(IServerRepository repository, IDataMapper dataMapper)
            : base(repository, dataMapper)
        {
        }
    }
}
