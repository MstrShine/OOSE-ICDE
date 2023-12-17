using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class ExamMap : VersionedEntityMapperBase<Domain.Exam, Persistency.Database.Domain.Exam>
    {

        public ExamMap() : base()
        {
        }

        protected override Persistency.Database.Domain.Exam _FromEntity(Persistency.Database.Domain.Exam dbEntity, Domain.Exam entity)
        {
            dbEntity.Weight = entity.Weight;
            dbEntity.Type = entity.Type;
            dbEntity.MinimumGrade = entity.MinimumGrade;
            dbEntity.LearningOutcomeUnitId = entity.LearningOutcomeUnitId;

            return dbEntity;
        }

        protected override Domain.Exam _ToEntity(Domain.Exam entity, Persistency.Database.Domain.Exam dbEntity)
        {
            entity.Weight = dbEntity.Weight;
            entity.Type = dbEntity.Type;
            entity.MinimumGrade = dbEntity.MinimumGrade;
            entity.LearningOutcomeUnitId = dbEntity.LearningOutcomeUnitId;

            return entity;
        }
    }
}
