using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Domain.Enums;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HAN.OOSE.ICDE.Domain
{
    public class Exam : VersionedEntity
    {
        public string? Name { get; set; }

        public string? Code { get; set; }

        public int? Weight { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ExamType? Type { get; set; }

        public int? MinimumGrade { get; set; }

        [DefaultValue(null)]
        public Guid? LearningOutcomeUnitId { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name)) return false;
            if (string.IsNullOrEmpty(Code)) return false;
            if (Weight == null || (Weight < 0 || Weight > 100)) return false;
            if (Type == null) return false;
            if (MinimumGrade == null || (MinimumGrade < 0 || MinimumGrade > 10)) return false;
            if (LearningOutcomeUnitId == null || LearningOutcomeUnitId == Guid.Empty) return false;

            return true;
        }
    }
}
