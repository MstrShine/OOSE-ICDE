using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentCriteria : Entity
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int MinimumGrade { get; set; }

        public List<GradeDescription> GradeDescriptions { get; set; }

        public string Explanation { get; set; }
    }
}
