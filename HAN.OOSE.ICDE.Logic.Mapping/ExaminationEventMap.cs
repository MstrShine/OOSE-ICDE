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
        public ExaminationEventMap(IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap) : base(userMap)
        {
        }

        protected override Persistency.Database.Domain.ExaminationEvent _FromEntity(Persistency.Database.Domain.ExaminationEvent dbEntity, Domain.ExaminationEvent entity)
        {
            dbEntity.Type = entity.Type;
            dbEntity.Date = entity.Date;
            dbEntity.Prerequisites = entity.Prerequisites;

            return dbEntity;
        }

        protected override Domain.ExaminationEvent _ToEntity(Domain.ExaminationEvent entity, Persistency.Database.Domain.ExaminationEvent dbEntity)
        {
            entity.Type = entity.Type;
            entity.Date = entity.Date;
            entity.Prerequisites = dbEntity.Prerequisites;

            return entity;
        }
    }
}
