using DistributionCenter.Core.Resources.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DistributionCenter.Core.Resources
{
    public abstract class FrameworkBaseResource : BaseResource
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Name { get; set; } = string.Empty;

        [JsonPropertyName("version")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Version { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Description { get; set; } = string.Empty;
    }

    public class FrameworkCreateResource : FrameworkBaseResource
    {
        [JsonIgnore]
        public override string? Id => base.Id;

        [JsonIgnore]
        public override DateTime? Created => base.Created;

        [JsonIgnore]
        public override DateTime? Updated => base.Updated;
    }

    public class FrameworkGetResource : FrameworkBaseResource
    {
    }
}
