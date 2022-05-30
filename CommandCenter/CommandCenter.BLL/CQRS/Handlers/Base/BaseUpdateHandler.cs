using CommandCenter.Core.Extensions;
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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommandCenter.BLL.CQRS.Handlers.Base
{
    public abstract class BaseUpdateHandler<TEntity, TModelCreate> : IBaseUpdateHandler<TEntity, TModelCreate>
        where TEntity : class, IBaseEntity, new()
        where TModelCreate : class, IBaseResource
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;
        protected readonly ILogger<BaseUpdateHandler<TEntity, TModelCreate>> _logger;

        public BaseUpdateHandler(IBaseRepository<TEntity> repository, IDataMapper dataMapper, ILogger<BaseUpdateHandler<TEntity, TModelCreate>> logger)
        {
            _repository = repository;
            _dataMapper = dataMapper;
            _logger = logger;
        }

        public virtual async Task<Unit> Handle(IBaseUpdateCommand<TModelCreate> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Trying to update {typeof(TEntity)} entity ...");

            var entity = (await _repository.FindAsync(x => x.Id == request.Id)).FirstOrDefault();
            if (entity == null)
            {
                throw new NotFoundException("NotFoundException occurred while updating the entity",
                    new ArgumentException($"Could not find entity with ID: {request.Id}.", nameof(request.Id)));
            }

            entity.CopyPropertiesFrom(request.Model);
            await _repository.UpdateAsync(entity);

            _logger.LogInformation($"{typeof(TEntity)} entity with Id {request.Id} was updated successfully.");

            return Unit.Value;
        }
    }
}
