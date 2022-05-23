using DistributionCenter.Core.Interfaces.Profiles.MapperProfiles;
using DistributionCenter.Core.Interfaces.Repositories.Base;
using DistributionCenter.Core.Interfaces.Services.Base;
using DistributionCenter.Core.Interfaces.Resources.Base;
using DistributionCenter.Core.Models.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DistributionCenter.Core.Extensions;
using DistributionCenter.Core.Interfaces.Entities.Base;

namespace DistributionCenter.BLL.Services.Base
{
    public abstract class BaseService<TModelCreate, TModelGet, TEntity> : IBaseService<TModelCreate, TModelGet, TEntity>
        where TModelCreate : class, IBaseResource
        where TModelGet : class, IBaseResource
        where TEntity : class, IBaseEntity, new()
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IDataMapper _dataMapper;

        public BaseService(IBaseRepository<TEntity> repository, IDataMapper dataMapper)
        {
            _repository = repository;
            _dataMapper = dataMapper;
        }

        public virtual async Task<string> CreateAsync(TModelCreate model)
        {
            var entity = new TEntity();
            entity.CopyPropertiesFrom(model);
            var id = await _repository.CreateAsync(entity);

            return id;
        }

        public virtual async Task UpdateAsync(string id, TModelCreate model)
        {
            var entity = (await _repository.FindAsync(x => x.Id == id)).FirstOrDefault();
            if (entity == null)
            {
                throw new NotFoundException("NotFoundException occurred while updating the entity",
                    new ArgumentException($"Could not find resource with ID: {id}.", nameof(id)));
            }

            entity.CopyPropertiesFrom(model);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task RemoveAsync(string id)
        {
            var entity = await _repository.GetAsync(id);
            if(entity == null)
            {
                throw new NotFoundException("NotFoundException occurred while removing the entity",
                    new ArgumentException($"Could not find resource with ID: {id}.", nameof(id)));
            }

            await _repository.RemoveAsync(entity);
        }

        public virtual async Task<TModelGet> GetAsync(string id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("NotFoundException occurred while getting the entity",
                    new ArgumentException($"Could not find resource with ID: {id}.", nameof(id)));
            }

            var model = _dataMapper.Map<TEntity, TModelGet>(entity);

            return model;
        }

        public virtual async Task<IEnumerable<TModelGet>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var models = _dataMapper.MapCollection<TEntity, TModelGet>(entities);

            return models;
        }
    }
}
