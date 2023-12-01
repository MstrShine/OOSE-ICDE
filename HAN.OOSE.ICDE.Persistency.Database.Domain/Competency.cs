using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Competency : VersionDBEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
