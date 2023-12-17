using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class AssessmentCriteriaMap : VersionedEntityMapperBase<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria>
    {
        public AssessmentCriteriaMap() : base()
        {
        }

        protected override Persistency.Database.Domain.AssessmentCriteria _FromEntity(Persistency.Database.Domain.AssessmentCriteria dbEntity, Domain.AssessmentCriteria entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Weight = entity.Weight;
            dbEntity.MinimumGrade = entity.MinimumGrade;
            dbEntity.Explanation = entity.Explanation;
            dbEntity.AssessmentDimensionId = entity.AssessmentDimensionId;

            return dbEntity;
        }

        protected override Domain.AssessmentCriteria _ToEntity(Domain.AssessmentCriteria entity, Persistency.Database.Domain.AssessmentCriteria dbEntity)
        {
            entity.Name = dbEntity.Name;
            entity.Weight = dbEntity.Weight;
            entity.MinimumGrade = dbEntity.MinimumGrade;
            entity.Explanation = dbEntity.Explanation;
            entity.AssessmentDimensionId = dbEntity.AssessmentDimensionId;

            return entity;
        }
    }
}
