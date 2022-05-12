using CommandCenter.Core.Entities.Enums;
using CommandCenter.Core.Interfaces.Resources.Base;
using System;
using System.Text.Json.Serialization;

namespace CommandCenter.Core.Resources.Base
{
    public abstract class BaseResource : IBaseResource
    {
        [JsonPropertyName("id")]
        public virtual string? Id { get; private set; }

        [JsonPropertyName("created")]
        public virtual DateTime? Created { get; private set; }

        [JsonPropertyName("updated")]
        public virtual DateTime? Updated { get; private set; }

        [JsonPropertyName("operationalStateStatus")]
        public virtual OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
