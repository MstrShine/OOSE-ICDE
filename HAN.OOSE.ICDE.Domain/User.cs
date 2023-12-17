using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Domain.Enums;

namespace HAN.OOSE.ICDE.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }
    }
}
