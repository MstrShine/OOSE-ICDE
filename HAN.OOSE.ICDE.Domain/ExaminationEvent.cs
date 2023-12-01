namespace HAN.OOSE.ICDE.Domain
{
    public class ExaminationEvent : Entity
    {
        public string Type { get; set; }

        public List<DateTime> Dates { get; set; }

        public string Prerequisites { get; set; }
    }
}
