using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.CQRS.Handlers.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using CommandCenter.Core.Models.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommandCenter.BLL.CQRS.Handlers.Base
{
    public abstract class BaseRemoveHandler<TEntity, TModelBase> : IBaseRemoveHandler<TEntity, TModelBase>
        where TEntity : class, IBaseEntity, new()
        where TModelBase : class, IBaseResource
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;
        protected readonly ILogger<BaseRemoveHandler<TEntity, TModelBase>> _logger;

        public BaseRemoveHandler(IBaseRepository<TEntity> repository, IDataMapper dataMapper, ILogger<BaseRemoveHandler<TEntity, TModelBase>> logger)
        {
            _repository = repository;
            _dataMapper = dataMapper;
            _logger = logger;
        }

        public virtual async Task<Unit> Handle(IBaseRemoveCommand<TModelBase> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Trying to remove {typeof(TEntity)} with ID: {request.Id} from a datastore ...");

            var entity = await _repository.GetAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("NotFoundException occurred while removing the entity",
                    new ArgumentException($"Could not find entity with ID: {request.Id}.", nameof(request.Id)));
            }

            await _repository.RemoveAsync(entity);

            _logger.LogInformation($"{typeof(TModelBase)} with ID: {request.Id} was removed successfully.");

            return Unit.Value;
        }
    }
}
