using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class CourseMap : VersionedEntityMapperBase<Domain.Course, Persistency.Database.Domain.Course>
    {
        public CourseMap() : base()
        {
        }

        protected override Persistency.Database.Domain.Course _FromEntity(Persistency.Database.Domain.Course dbEntity, Domain.Course entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Code = entity.Code;
            dbEntity.CollegeYear = entity.CollegeYear;
            dbEntity.CTE = entity.CTE;
            dbEntity.IsFinalized = entity.IsFinalized;
            dbEntity.StudyId = entity.StudyId;

            return dbEntity;
        }

        protected override Domain.Course _ToEntity(Domain.Course entity, Persistency.Database.Domain.Course dbEntity)
        {
            entity.Name = entity.Name;
            entity.Description = entity.Description;
            entity.Code = dbEntity.Code;
            entity.CollegeYear = dbEntity.CollegeYear;
            entity.CTE = dbEntity.CTE;
            entity.IsFinalized = dbEntity.IsFinalized;
            entity.StudyId = dbEntity.StudyId;

            return entity;
        }
    }
}
