using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class LessonMap : VersionedEntityMapperBase<Domain.Lesson, Persistency.Database.Domain.Lesson>
    {
        private readonly IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> _learningOutcomeMap;

        public LessonMap(
            IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap, 
            IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> learningOutcomeMap) : base(userMap)
        {
            _learningOutcomeMap = learningOutcomeMap;
        }

        protected override Persistency.Database.Domain.Lesson _FromEntity(Persistency.Database.Domain.Lesson dbEntity, Domain.Lesson entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Didactics = entity.Didactics;
            dbEntity.Date = entity.Date;
            dbEntity.LearningOutcomes = entity.LearningOutcomes.Select(x => _learningOutcomeMap.FromEntity(x)).ToList();

            return dbEntity;
        }

        protected override Domain.Lesson _ToEntity(Domain.Lesson entity, Persistency.Database.Domain.Lesson dbEntity)
        {
            entity.Name = dbEntity.Name;
            entity.Description = dbEntity.Description;
            entity.Didactics = dbEntity.Didactics;
            entity.Date = dbEntity.Date;
            entity.LearningOutcomes = dbEntity.LearningOutcomes.Select(x => _learningOutcomeMap.ToEntity(x)).ToList();

            return entity;
        }
    }
}
