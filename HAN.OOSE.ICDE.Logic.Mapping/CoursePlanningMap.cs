using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class CoursePlanningMap : VersionedEntityMapperBase<Domain.CoursePlanning, Persistency.Database.Domain.CoursePlanning>
    {
        public CoursePlanningMap() : base()
        {
        }

        protected override Persistency.Database.Domain.CoursePlanning _FromEntity(Persistency.Database.Domain.CoursePlanning dbEntity, Domain.CoursePlanning entity)
        {
            dbEntity.CourseId = entity.CourseId;

            return dbEntity;
        }

        protected override Domain.CoursePlanning _ToEntity(Domain.CoursePlanning entity, Persistency.Database.Domain.CoursePlanning dbEntity)
        {
            entity.CourseId = dbEntity.CourseId;

            return entity;
        }
    }
}
