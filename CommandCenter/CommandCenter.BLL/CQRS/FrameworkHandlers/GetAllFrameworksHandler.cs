using CommandCenter.BLL.CQRS.Base.Handlers;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories;
using CommandCenter.Core.Resources;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.CQRS.FrameworkHandlers
{
    public class GetAllFrameworksHandler : GetAllResourcesBaseHandler<Framework, FrameworkGetResource>, IGetAllFrameworksHandler
    {
        public GetAllFrameworksHandler(IFrameworkRepository repository, IDataMapper dataMapper, ILogger<GetAllFrameworksHandler> logger)
            : base(repository, dataMapper, logger)
        {
        }
    }
}
