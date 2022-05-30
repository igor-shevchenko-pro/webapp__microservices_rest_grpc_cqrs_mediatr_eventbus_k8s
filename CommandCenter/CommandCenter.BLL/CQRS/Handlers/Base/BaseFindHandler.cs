using CommandCenter.Core.Interfaces.CQRS.Handlers.Base;
using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CommandCenter.BLL.CQRS.Handlers.Base
{
    public abstract class BaseFindHandler<TEntity, TModelGet> : IBaseFindHandler<TEntity, TModelGet>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;
        protected readonly ILogger<BaseFindHandler<TEntity, TModelGet>> _logger;

        public BaseFindHandler(IBaseRepository<TEntity> repository, IDataMapper dataMapper, ILogger<BaseFindHandler<TEntity, TModelGet>> logger)
        {
            _repository = repository;
            _dataMapper = dataMapper;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<TModelGet>> Handle(IBaseFindQuery<TEntity, TModelGet> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Trying to find a collection of {typeof(TEntity)} in a datastore based on request condition ...");

            var entities = await _repository.FindAsync(request.Predicate);
            var models = _dataMapper.MapCollection<TEntity, TModelGet>(entities);

            _logger.LogInformation($"{typeof(TModelGet)} was received successfully.");

            return models;
        }
    }
}
