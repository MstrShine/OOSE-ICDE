using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class LearningOutcome : VersionDBEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
