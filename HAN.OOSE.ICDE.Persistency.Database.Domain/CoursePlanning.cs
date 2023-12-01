namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class CoursePlanning : VersionDBEntity
    {
        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<ExaminationEvent> Examinations { get; set; }
    }
}
