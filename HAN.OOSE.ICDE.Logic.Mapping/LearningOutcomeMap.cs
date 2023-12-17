using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class LearningOutcomeMap : VersionedEntityMapperBase<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome>
    {
        public LearningOutcomeMap() : base()
        {
        }

        protected override Persistency.Database.Domain.LearningOutcome _FromEntity(Persistency.Database.Domain.LearningOutcome dbEntity, Domain.LearningOutcome entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.ExamId = entity.ExamId;
            dbEntity.LearningOutcomeUnitId = entity.LearningOutcomeUnitId;
            dbEntity.LessonId = entity.LessonId;

            return dbEntity;
        }

        protected override Domain.LearningOutcome _ToEntity(Domain.LearningOutcome entity, Persistency.Database.Domain.LearningOutcome dbEntity)
        {
            entity.Name = dbEntity.Name;
            entity.Description = dbEntity.Description;
            entity.ExamId = dbEntity.ExamId;
            entity.LearningOutcomeUnitId = dbEntity.LearningOutcomeUnitId;
            entity.LessonId = dbEntity.LessonId;

            return entity;
        }
    }
}
