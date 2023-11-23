using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentDimension : Entity
    {
        public string Description { get; set; }

        public List<AssessmentCriteria> Criterias { get; set; }
    }
}
