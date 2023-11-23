using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Domain
{
    public class Lesson : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Didactics { get; set; }

        public DateTime Date { get; set; }

        public List<LearningOutcome> LearningOutcomes { get; set; }
    }
}
