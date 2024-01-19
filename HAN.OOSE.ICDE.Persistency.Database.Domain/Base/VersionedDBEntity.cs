namespace HAN.OOSE.ICDE.Persistency.Database.Domain.Base
{
    public abstract class VersionedDBEntity : DBEntity
    {
        public Guid VersionCollection { get; set; }

        public Guid Author { get; set; }

        public DateTime? DateOfCreation { get; set; }
    }
}
