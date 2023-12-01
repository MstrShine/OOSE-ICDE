namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class ExaminationEvent : VersionDBEntity
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Prerequisites { get; set; }
    }
}
