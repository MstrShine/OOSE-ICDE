using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Domain.Base
{
    public abstract class VersionedEntity : Entity
    {
        public Guid VersionCollection { get; set; }

        public User Author { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
