using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class ExaminationEventMap : VersionedEntityMapperBase<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent>
    {
        public ExaminationEventMap() : base()
        {
        }

        protected override Persistency.Database.Domain.ExaminationEvent _FromEntity(Persistency.Database.Domain.ExaminationEvent dbEntity, Domain.ExaminationEvent entity)
        {
            dbEntity.Type = entity.Type;
            dbEntity.Date = entity.Date;
            dbEntity.Prerequisites = entity.Prerequisites;
            dbEntity.CoursePlanningId = entity.CoursePlanningId;
            dbEntity.ExamId = entity.ExamId;

            return dbEntity;
        }

        protected override Domain.ExaminationEvent _ToEntity(Domain.ExaminationEvent entity, Persistency.Database.Domain.ExaminationEvent dbEntity)
        {
            entity.Type = dbEntity.Type;
            entity.Date = dbEntity.Date;
            entity.Prerequisites = dbEntity.Prerequisites;
            entity.CoursePlanningId = dbEntity.CoursePlanningId;
            entity.ExamId = dbEntity.ExamId;

            return entity;
        }
    }
}
