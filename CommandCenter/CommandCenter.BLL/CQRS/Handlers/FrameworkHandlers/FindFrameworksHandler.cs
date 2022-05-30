using CommandCenter.BLL.CQRS.Handlers.Base;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories;
using CommandCenter.Core.Resources;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.CQRS.Handlers.FrameworkHandlers
{
    public class FindFrameworksHandler : BaseFindHandler<Framework, FrameworkGetResource>, IFindFrameworksHandler
    {
        public FindFrameworksHandler(IFrameworkRepository repository, IDataMapper dataMapper, ILogger<FindFrameworksHandler> logger)
            : base(repository, dataMapper, logger)
        {
        }
    }
}
