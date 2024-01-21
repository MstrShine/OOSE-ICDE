using HAN.OOSE.ICDE.Domain.Base;
using System.Text.Json.Serialization;

namespace HAN.OOSE.ICDE.Domain
{
    public class Study : Entity
    {
        public string? Name { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
