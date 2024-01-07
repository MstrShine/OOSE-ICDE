using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class LearningOutcomeUnitMap : VersionedEntityMapperBase<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit>
    {
        public LearningOutcomeUnitMap() : base() 
        {
        }

        protected override Persistency.Database.Domain.LearningOutcomeUnit _FromEntity(Persistency.Database.Domain.LearningOutcomeUnit dbEntity, Domain.LearningOutcomeUnit entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Code = entity.Code;
            dbEntity.CTE = entity.CTE;
            dbEntity.MinimumGrade = entity.MinimumGrade;
            dbEntity.CourseId = entity.CourseId;

            return dbEntity;
        }

        protected override Domain.LearningOutcomeUnit _ToEntity(Domain.LearningOutcomeUnit entity, Persistency.Database.Domain.LearningOutcomeUnit dbEntity)
        {
            entity.Name = dbEntity.Name;
            entity.Code = dbEntity.Code;
            entity.CTE = dbEntity.CTE;
            entity.MinimumGrade = dbEntity.MinimumGrade;
            entity.CourseId = dbEntity.CourseId;

            return entity;
        }
    }
}
