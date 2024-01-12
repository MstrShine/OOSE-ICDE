using HAN.OOSE.ICDE.API.Converters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HAN.OOSE.ICDE.Domain.Base
{
    public abstract class VersionedEntity : Entity
    {
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        [JsonConverter(typeof(GuidJsonConverter))]
        public Guid VersionCollection { get; set; }

        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        [JsonConverter(typeof(GuidJsonConverter))]
        public Guid Author { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
