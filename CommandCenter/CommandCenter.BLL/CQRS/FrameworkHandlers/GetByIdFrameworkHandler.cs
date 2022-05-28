using CommandCenter.BLL.CQRS.Base.Handlers;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories;
using CommandCenter.Core.Resources;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.CQRS.FrameworkHandlers
{
    public class GetByIdFrameworkHandler : BaseGetByIdHandler<Framework, FrameworkGetResource>, IGetByIdFrameworkHandler
    {
        public GetByIdFrameworkHandler(IFrameworkRepository repository, IDataMapper dataMapper, ILogger<GetByIdFrameworkHandler> logger)
            : base(repository, dataMapper, logger)
        {
        }
    }
}
