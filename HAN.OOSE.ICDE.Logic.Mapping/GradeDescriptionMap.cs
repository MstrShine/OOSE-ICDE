using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class GradeDescriptionMap : VersionedEntityMapperBase<Domain.GradeDescription, Persistency.Database.Domain.GradeDescription>
    {
        public GradeDescriptionMap() : base()
        {
        }

        protected override Persistency.Database.Domain.GradeDescription _FromEntity(Persistency.Database.Domain.GradeDescription dbEntity, Domain.GradeDescription entity)
        {
            dbEntity.Grade = entity.Grade;
            dbEntity.Description = entity.Description;
            dbEntity.AssessmentCriteriaId = entity.AssessmentCriteriaId;

            return dbEntity;
        }

        protected override Domain.GradeDescription _ToEntity(Domain.GradeDescription entity, Persistency.Database.Domain.GradeDescription dbEntity)
        {
            entity.Grade = entity.Grade;
            entity.Description = entity.Description;
            entity.AssessmentCriteriaId = dbEntity.AssessmentCriteriaId;

            return entity;
        }
    }
}
