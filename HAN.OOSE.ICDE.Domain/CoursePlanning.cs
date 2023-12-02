namespace HAN.OOSE.ICDE.Domain
{
    public class CoursePlanning : VersionedEntity
    {
        public List<Lesson> Lessons { get; set; }

        public List<ExaminationEvent> Examinations { get; set; }
    }
}
