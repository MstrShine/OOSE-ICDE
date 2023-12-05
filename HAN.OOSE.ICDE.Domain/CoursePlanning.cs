namespace HAN.OOSE.ICDE.Domain
{
    public class CoursePlanning : VersionedEntity
    {
        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<ExaminationEvent> Examinations { get; set; }
    }
}
