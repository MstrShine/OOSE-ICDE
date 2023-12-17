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
        public AssessmentDimensionMap() : base()
        {
        }

        protected override Persistency.Database.Domain.AssessmentDimension _FromEntity(Persistency.Database.Domain.AssessmentDimension dbEntity, Domain.AssessmentDimension entity)
        {
            dbEntity.Description = entity.Description;
            dbEntity.ExamId = entity.ExamId;

            return dbEntity;
        }

        protected override Domain.AssessmentDimension _ToEntity(Domain.AssessmentDimension entity, Persistency.Database.Domain.AssessmentDimension dbEntity)
        {
            entity.Description = dbEntity.Description;
            entity.ExamId = dbEntity.ExamId;

            return entity;
        }
    }
}
