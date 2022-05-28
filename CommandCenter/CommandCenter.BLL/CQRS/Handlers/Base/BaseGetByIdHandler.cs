using CommandCenter.Core.Interfaces.CQRS.Handlers.Base;
using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using CommandCenter.Core.Models.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommandCenter.BLL.CQRS.Handlers.Base
{
    public abstract class BaseGetByIdHandler<TEntity, TModelGet> : IBaseGetByIdHandler<TEntity, TModelGet>
        where TEntity : class, IBaseEntity, new()
        where TModelGet : class, IBaseResource
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;
        protected readonly ILogger<BaseGetByIdHandler<TEntity, TModelGet>> _logger;

        public BaseGetByIdHandler(IBaseRepository<TEntity> repository, IDataMapper dataMapper, ILogger<BaseGetByIdHandler<TEntity, TModelGet>> logger)
        {
            _repository = repository;
            _dataMapper = dataMapper;
            _logger = logger;
        }

        public virtual async Task<TModelGet> Handle(IBaseGetByIdQuery<TModelGet> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Trying to fetch {typeof(TEntity)} from a datastore ...");

            var entity = await _repository.GetAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("NotFoundException occurred while getting the entity",
                    new ArgumentException($"Could not find entity with ID: {request.Id}.", nameof(request.Id)));
            }

            var model = _dataMapper.Map<TEntity, TModelGet>(entity);

            _logger.LogInformation($"{typeof(TModelGet)} was received successfully.");

            return model;
        }
    }
}
