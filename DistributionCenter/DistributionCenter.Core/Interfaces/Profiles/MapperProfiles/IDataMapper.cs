using System.Collections.Generic;

namespace DistributionCenter.Core.Interfaces.Profiles.MapperProfiles
{
    public interface IDataMapper
    {
        To Map<From, To>(From model);
        IEnumerable<To> MapCollection<From, To>(IEnumerable<From> models);
    }
}
