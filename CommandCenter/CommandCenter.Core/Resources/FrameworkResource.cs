using CommandCenter.Core.Resources.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CommandCenter.Core.Resources
{
    public abstract class FrameworkBaseResource : BaseResource
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Name { get; set; } = string.Empty;

        [JsonPropertyName("version")]
        [Required(AllowEmptyStrings = false)]
        public virtual string Version { get; set; } = string.Empty;

        [JsonPropertyName("releaseDate")]
        [Required(AllowEmptyStrings = false)]
        public virtual DateTime ReleaseDate { get; set; }
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
