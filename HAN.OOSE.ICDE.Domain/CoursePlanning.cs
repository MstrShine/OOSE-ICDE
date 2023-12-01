namespace HAN.OOSE.ICDE.Domain
{
    public class CoursePlanning : Entity
    {
        public List<Lesson> Lessons { get; set; }

        public List<ExaminationEvent> Examinations { get; set; }
    }
}
