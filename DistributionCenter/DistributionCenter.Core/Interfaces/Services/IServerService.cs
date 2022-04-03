using DistributionCenter.API.Resources;
using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Interfaces.Services.Base;

namespace DistributionCenter.Core.Interfaces.Services
{
    public interface IServerService : IBaseService<ServerCreateResource, ServerGetResource, Server>
    {
    }
}
