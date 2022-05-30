using CommandCenter.BLL.CQRS.Handlers.Base;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories;
using CommandCenter.Core.Resources;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.CQRS.Handlers.FrameworkHandlers
{
    public class UpdateFrameworkHandler : BaseUpdateHandler<Framework, FrameworkCreateResource>, IUpdateFrameworkHandler
    {
        public UpdateFrameworkHandler(IFrameworkRepository repository, IDataMapper dataMapper, ILogger<UpdateFrameworkHandler> logger)
            : base(repository, dataMapper, logger)
        {
        }
    }
}
