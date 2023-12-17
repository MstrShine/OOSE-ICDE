using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class CompetencyMap : VersionedEntityMapperBase<Domain.Competency, Persistency.Database.Domain.Competency>
    {
        public CompetencyMap() : base()
        {
        }

        protected override Persistency.Database.Domain.Competency _FromEntity(Persistency.Database.Domain.Competency dbEntity, Domain.Competency entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Code = entity.Code;
            dbEntity.CourseId = entity.CourseId;
            dbEntity.LearningOutcomeUnitId = entity.LearningOutcomeUnitId;

            return dbEntity;
        }

        protected override Domain.Competency _ToEntity(Domain.Competency entity, Persistency.Database.Domain.Competency dbEntity)
        {
            entity.Name = dbEntity.Name;
            entity.Code = dbEntity.Code;
            entity.CourseId = dbEntity.CourseId;
            entity.LearningOutcomeUnitId = dbEntity.LearningOutcomeUnitId;

            return entity;
        }
    }
}
