using AutoMapper;
using DistributionCenter.Core.Interfaces.Profiles.MapperProfiles;
using System.Collections.Generic;
using System.Linq;

namespace DistributionCenter.Core.Profiles.MapperProfiles
{
    public class DataMapper : IDataMapper
    {
        IMapper _mapper;

        public DataMapper(IMapper dataAdapter)
        {
            _mapper = dataAdapter;
        }

        public To Map<From, To>(From model)
        {
            return _mapper.Map<From, To>(model);
        }

        public IEnumerable<To> MapCollection<From, To>(IEnumerable<From> models)
        {
            return models.Select(Map<From, To>).ToList();
        }
    }
}
