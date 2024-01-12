using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Domain.Enums;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HAN.OOSE.ICDE.Domain
{
    public class Exam : VersionedEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int Weight { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ExamType Type { get; set; }

        public int MinimumGrade { get; set; }

        [DefaultValue(null)]
        public Guid? LearningOutcomeUnitId { get; set; }
    }
}
