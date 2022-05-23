using CommandCenter.BLL.Services.CQRS.Framework.Queries;
using CommandCenter.Core.Repositories;
using CommandCenter.Core.Resources;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandCenter.BLL.Services.CQRS.Framework.Handlers
{
    public class GetFrameworksHandler : IRequestHandler<GetFrameworksQuery, IEnumerable<FrameworkGetResource>>
    {
        private readonly IFrameworkRepository _frameworkRepository;
        private readonly ILogger<GetFrameworksHandler> _logger;

        public GetFrameworksHandler(IFrameworkRepository frameworkRepository, ILogger<GetFrameworksHandler> logger)
        {
            _frameworkRepository = frameworkRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<FrameworkGetResource>> Handle(GetFrameworksQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Trying to fetch frameworks from a datastore ...");

            var entities = await _frameworkRepository.GetAllAsync();

            _logger.LogInformation("Frameworks were received successfully.");

            return null;
        }
    }
}
