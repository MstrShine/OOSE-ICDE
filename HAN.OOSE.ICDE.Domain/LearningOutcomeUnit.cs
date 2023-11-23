using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Domain
{
    public class LearningOutcomeUnit : Entity
    {
        public string Code { get; set; }

        public double CTE { get; set; }

        public double MinimumGrade { get; set; }

        public List<Exam> Exams { get; set; }

        public List<LearningOutcome> LearningOutcomes { get; set; }

        public List<Competency> Competencies { get; set; }
    }
}
