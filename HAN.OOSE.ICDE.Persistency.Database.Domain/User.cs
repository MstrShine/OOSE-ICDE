using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Enums;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class User : DBEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }
    }
}
