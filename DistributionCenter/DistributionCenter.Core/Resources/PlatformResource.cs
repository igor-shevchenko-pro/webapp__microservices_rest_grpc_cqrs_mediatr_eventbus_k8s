using System.Text.Json.Serialization;
using DistributionCenter.Core.Resources.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistributionCenter.Core.Resources
{
    public abstract class PlatformBaseResource : BaseResource
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Name { get; set; } = string.Empty;

        [JsonPropertyName("publisher")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Publisher { get; set; } = string.Empty;

        [JsonPropertyName("cost")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Cost { get; set; } = string.Empty;
    }

    public class PlatformCreateResource : PlatformBaseResource
    {
        [JsonIgnore]
        public override string? Id => base.Id;

        [JsonIgnore]
        public override DateTime? Created => base.Created;

        [JsonIgnore]
        public override DateTime? Updated => base.Updated;
    }

    public class PlatformGetResource : PlatformBaseResource
    {
    }
}
