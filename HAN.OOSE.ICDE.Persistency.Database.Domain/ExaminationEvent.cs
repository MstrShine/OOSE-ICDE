using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class ExaminationEvent : DBEntity
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Prerequisites { get; set; }
    }
}
