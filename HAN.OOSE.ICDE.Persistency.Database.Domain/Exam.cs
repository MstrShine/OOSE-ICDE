using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Exam : DBEntity
    {
        public int Weight { get; set; }

        public string Type { get; set; }

        public int MinimumGrade { get; set; }

        public List<LearningOutcome> LearningOutcomes { get; set; }

        public List<AssessmentDimension> AssessmentDimensions { get; set; }

        public ExaminationEvent ExaminationEvent { get; set; }
    }
}
