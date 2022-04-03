using System.Text.Json.Serialization;
using DistributionCenter.Core.Resources.Base;
using System;
using System.ComponentModel.DataAnnotations;
using DistributionCenter.Core.Entities.Enums;

namespace DistributionCenter.API.Resources
{
    public abstract class ServerBaseResource : BaseResource
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Name { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = false)]
        public virtual ServerType Type { get; set; }
    }

    public class ServerCreateResource : ServerBaseResource
    {
        [JsonIgnore]
        public override string? Id => base.Id;

        [JsonIgnore]
        public override DateTime? Created => base.Created;

        [JsonIgnore]
        public override DateTime? Updated => base.Updated;
    }

    public class ServerGetResource : ServerBaseResource
    {
    }
}
