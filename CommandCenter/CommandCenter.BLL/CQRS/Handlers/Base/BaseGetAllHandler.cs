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
    public abstract class BaseGetAllHandler<TEntity, TModelGet> : IBaseGetAllHandler<TEntity, TModelGet>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;
        protected readonly ILogger<BaseGetAllHandler<TEntity, TModelGet>> _logger;

        public BaseGetAllHandler(IBaseRepository<TEntity> repository, IDataMapper dataMapper, ILogger<BaseGetAllHandler<TEntity, TModelGet>> logger)
        {
            _repository = repository;
            _dataMapper = dataMapper;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<TModelGet>> Handle(IBaseGetAllQuery<TModelGet> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Trying to fetch {typeof(TEntity)} from a datastore ...");

            var entities = await _repository.GetAllAsync();
            var models = _dataMapper.MapCollection<TEntity, TModelGet>(entities);

            _logger.LogInformation($"{typeof(TModelGet)} were received successfully.");

            return models;
        }
    }
}
