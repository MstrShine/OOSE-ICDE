using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Domain
{
    public class Course : Entity
    {
        public string StudyProgram { get; set; }

        public string Code { get; set; }

        public int CollegeYear { get; set; }

        public int CTE {  get; set; }

        public List<LearningOutcomeUnit> LearningOutcomeUnits { get; set; }

        public List<Competency> Competencies { get; set; }

        public CoursePlanning CoursePlanning { get; set; }
    }
}
