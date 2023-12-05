using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class AssessmentDimensionMap : VersionedEntityMapperBase<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension>
    {
        private readonly IEntityMapper<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria> _assessmentCriteriaMap;

        public AssessmentDimensionMap(
            IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap,
            IEntityMapper<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria> assessmentCriteriaMap) : base(userMap)
        {
            _assessmentCriteriaMap = assessmentCriteriaMap;
        }

        protected override Persistency.Database.Domain.AssessmentDimension _FromEntity(Persistency.Database.Domain.AssessmentDimension dbEntity, Domain.AssessmentDimension entity)
        {
            dbEntity.Description = entity.Description;
            dbEntity.Criterias = entity.Criterias.Select(x => _assessmentCriteriaMap.FromEntity(x)).ToList();

            return dbEntity;
        }

        protected override Domain.AssessmentDimension _ToEntity(Domain.AssessmentDimension entity, Persistency.Database.Domain.AssessmentDimension dbEntity)
        {
            entity.Description = dbEntity.Description;
            entity.Criterias = dbEntity.Criterias.Select(x => _assessmentCriteriaMap.ToEntity(x)).ToList();

            return entity;
        }
    }
}
