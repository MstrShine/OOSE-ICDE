namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class LessonMap : VersionedEntityMapperBase<Domain.Lesson, Persistency.Database.Domain.Lesson>
    {
        public LessonMap() : base()
        {
        }

        protected override Persistency.Database.Domain.Lesson _FromEntity(Persistency.Database.Domain.Lesson dbEntity, Domain.Lesson entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Didactics = entity.Didactics;
            dbEntity.Date = entity.Date;
            dbEntity.CoursePlanningId = entity.CoursePlanningId;
            dbEntity.LearningOutcomeId = entity.LearningOutcomeId;

            return dbEntity;
        }

        protected override Domain.Lesson _ToEntity(Domain.Lesson entity, Persistency.Database.Domain.Lesson dbEntity)
        {
            entity.Name = dbEntity.Name;
            entity.Description = dbEntity.Description;
            entity.Didactics = dbEntity.Didactics;
            entity.Date = dbEntity.Date;
            entity.CoursePlanningId = dbEntity.CoursePlanningId;
            entity.LearningOutcomeId = dbEntity.LearningOutcomeId;

            return entity;
        }
    }
}
