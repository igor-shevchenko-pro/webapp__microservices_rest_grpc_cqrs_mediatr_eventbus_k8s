using CommandCenter.Core.Extensions;
using CommandCenter.Core.Interfaces.CQRS.Commands.Base;
using CommandCenter.Core.Interfaces.CQRS.Handlers.Base;
using CommandCenter.Core.Interfaces.Entities.Base;
using CommandCenter.Core.Interfaces.EventSenderHubs;
using CommandCenter.Core.Interfaces.EventSenderHubs.Base;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Interfaces.Repositories.Base;
using CommandCenter.Core.Interfaces.Resources.Base;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CommandCenter.BLL.CQRS.Handlers.Base
{
    public abstract class BaseCreateHandler<TEntity, TModelCreate> : IBaseCreateHandler<TEntity, TModelCreate>
        where TEntity : class, IBaseEntity, new()
        where TModelCreate : class, IBaseResource
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;
        //protected readonly IBaseEventSenderHub<TModelGet> _eventSenderHub;
        protected readonly ILogger<BaseCreateHandler<TEntity, TModelCreate>> _logger;

        public BaseCreateHandler(
            IBaseRepository<TEntity> repository,
            IDataMapper dataMapper,
            //IBaseEventSenderHub<TModelGet> _eventSenderHub,
            ILogger<BaseCreateHandler<TEntity, TModelCreate>> logger)
        {
            _repository = repository;
            _dataMapper = dataMapper;
            //_eventSenderHub = _eventSenderHub; // <--
            _logger = logger;
        }

        public virtual async Task<string> Handle(IBaseCreateCommand<TModelCreate> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Trying to create {typeof(TEntity)} entity ...");

            var entity = new TEntity();
            entity.CopyPropertiesFrom(request.Model);
            var id = await _repository.CreateAsync(entity);

            _logger.LogInformation($"{typeof(TEntity)} entity with Id {id} was created successfully.");


            // need refactoring <--
            //await _protocolEventSenderHub.UpdateGeneralStatusAsync(entity);

            return id;
        }
    }
}
