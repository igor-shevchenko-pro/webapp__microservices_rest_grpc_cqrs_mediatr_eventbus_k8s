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

namespace CommandCenter.BLL.CQRS.Base.Handlers
{
    public abstract class GetAllResourcesBaseHandler<TEntity, TModelGet> : IGetAllResourcesBaseHandler<TEntity, TModelGet>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;
        protected readonly ILogger<GetAllResourcesBaseHandler<TEntity, TModelGet>> _logger;

        public GetAllResourcesBaseHandler(IBaseRepository<TEntity> repository, IDataMapper dataMapper, ILogger<GetAllResourcesBaseHandler<TEntity, TModelGet>> logger)
        {
            _repository = repository;
            _dataMapper = dataMapper;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<TModelGet>> Handle(IGetAllResourcesBaseQuery<TModelGet> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Trying to fetch {typeof(TEntity)} from a datastore ...");

            var entities = await _repository.GetAllAsync();
            var models = _dataMapper.MapCollection<TEntity, TModelGet>(entities);

            _logger.LogInformation($"{typeof(TModelGet)} were received successfully.");

            return models;
        }
    }
}
