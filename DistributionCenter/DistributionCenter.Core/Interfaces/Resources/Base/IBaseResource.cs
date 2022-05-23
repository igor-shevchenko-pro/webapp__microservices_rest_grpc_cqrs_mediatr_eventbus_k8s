using DistributionCenter.Core.Entities.Enums;
using System;

namespace DistributionCenter.Core.Interfaces.Resources.Base
{
    public interface IBaseResource
    {
        string? Id { get; }
        DateTime? Created { get; }
        DateTime? Updated { get; }
        OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
