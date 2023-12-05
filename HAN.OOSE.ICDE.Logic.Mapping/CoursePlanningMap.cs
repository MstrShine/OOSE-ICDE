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
        private readonly IEntityMapper<Domain.Course, Persistency.Database.Domain.Course> _courseMap;
        private readonly IEntityMapper<Domain.Lesson, Persistency.Database.Domain.Lesson> _lessonMap;
        private readonly IEntityMapper<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent> _examinationEventMap; 

        public CoursePlanningMap(
            IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap,
            IEntityMapper<Domain.Course, Persistency.Database.Domain.Course> courseMap,
            IEntityMapper<Domain.Lesson, Persistency.Database.Domain.Lesson> lessonMap,
            IEntityMapper<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent> examinationEventMap) : base(userMap)
        {
            _courseMap = courseMap;
            _lessonMap = lessonMap;
            _examinationEventMap = examinationEventMap;
        }

        protected override Persistency.Database.Domain.CoursePlanning _FromEntity(Persistency.Database.Domain.CoursePlanning dbEntity, Domain.CoursePlanning entity)
        {
            dbEntity.CourseId = entity.CourseId;
            dbEntity.Course = _courseMap.FromEntity(entity.Course);
            dbEntity.Lessons = entity.Lessons.Select(x => _lessonMap.FromEntity(x)).ToList();
            dbEntity.Examinations = entity.Examinations.Select(x => _examinationEventMap.FromEntity(x)).ToList();

            return dbEntity;
        }

        protected override Domain.CoursePlanning _ToEntity(Domain.CoursePlanning entity, Persistency.Database.Domain.CoursePlanning dbEntity)
        {
            entity.CourseId = dbEntity.CourseId;
            entity.Course = _courseMap.ToEntity(dbEntity.Course);
            entity.Lessons = dbEntity.Lessons.Select(x => _lessonMap.ToEntity(x)).ToList();
            entity.Examinations = dbEntity.Examinations.Select(x => _examinationEventMap.ToEntity(x)).ToList();

            return entity;
        }
    }
}
