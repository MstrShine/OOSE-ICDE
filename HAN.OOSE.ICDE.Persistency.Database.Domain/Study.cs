using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Study : DBEntity
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
