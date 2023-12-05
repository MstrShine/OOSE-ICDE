namespace HAN.OOSE.ICDE.Domain
{
    public class ExaminationEvent : VersionedEntity
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Prerequisites { get; set; }
    }
}
