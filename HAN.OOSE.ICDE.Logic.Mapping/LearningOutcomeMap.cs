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
        public LearningOutcomeMap(IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap) : base(userMap)
        {
        }

        protected override Persistency.Database.Domain.LearningOutcome _FromEntity(Persistency.Database.Domain.LearningOutcome dbEntity, Domain.LearningOutcome entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;

            return dbEntity;
        }

        protected override Domain.LearningOutcome _ToEntity(Domain.LearningOutcome entity, Persistency.Database.Domain.LearningOutcome dbEntity)
        {
            entity.Name = entity.Name;
            entity.Description = entity.Description;

            return entity;
        }
    }
}
