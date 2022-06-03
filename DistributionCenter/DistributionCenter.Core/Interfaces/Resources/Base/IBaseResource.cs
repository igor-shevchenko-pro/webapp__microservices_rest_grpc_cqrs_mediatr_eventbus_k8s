using DistributionCenter.Core.Entities.Enums;
using System;

namespace DistributionCenter.Core.Interfaces.Resources.Base
{
    public interface IBaseResource
    {
        string? Id { get; set; }
        DateTime? Created { get; set; }
        DateTime? Updated { get; set; }
        OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
