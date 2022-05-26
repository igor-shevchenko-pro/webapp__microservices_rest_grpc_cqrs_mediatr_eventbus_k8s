using CommandCenter.Core.Enums;
using CommandCenter.Core.Resources.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CommandCenter.Core.Resources
{
    public abstract class ProtocolBaseResource : BaseResource
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Description { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = false)]
        public virtual ProtocolType Type { get; set; }
    }

    public class ProtocolCreateResource : ProtocolBaseResource
    {
        [JsonIgnore]
        public override string? Id => base.Id;

        [JsonIgnore]
        public override DateTime? Created => base.Created;

        [JsonIgnore]
        public override DateTime? Updated => base.Updated;
    }

    public class ProtocolGetResource : ProtocolBaseResource
    {
    }
}
