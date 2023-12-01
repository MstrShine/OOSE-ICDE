using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class AssessmentDimension : VersionDBEntity
    {
        public string Description { get; set; }

        public List<AssessmentCriteria> Criterias { get; set; }
    }
}
