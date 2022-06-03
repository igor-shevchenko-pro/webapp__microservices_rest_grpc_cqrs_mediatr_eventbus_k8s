using DistributionCenter.Core.Entities.Enums;
using DistributionCenter.Core.Interfaces.Resources.Base;
using System;
using System.Text.Json.Serialization;

namespace DistributionCenter.Core.Resources.Base
{
    public abstract class BaseResource : IBaseResource
    {
        [JsonPropertyName("id")]
        public virtual string? Id { get; set; }

        [JsonPropertyName("created")]
        public virtual DateTime? Created { get; set; }

        [JsonPropertyName("updated")]
        public virtual DateTime? Updated { get; set; }

        [JsonPropertyName("operationalStateStatus")]
        public virtual OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
