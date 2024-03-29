﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class CoursePlanningManager : VersionedEntityManager<CoursePlanning, Persistency.Database.Domain.CoursePlanning, ICoursePlanningRepositorySession>, ICoursePlanningManager
    {
        private readonly IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> _examinationEventRepository;
        private readonly IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> _lessonRepository;

        public CoursePlanningManager(
            IEntityRepository<ICoursePlanningRepositorySession, Persistency.Database.Domain.CoursePlanning> repository,
            IEntityMapper<CoursePlanning, Persistency.Database.Domain.CoursePlanning> mapper,
            IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> examinationEventRepository,
            IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> lessonRepository) : base(repository, mapper)
        {
            _examinationEventRepository = examinationEventRepository;
            _lessonRepository = lessonRepository;
        }

        public async Task<CoursePlanning> GetByCourseIdAsync(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            CoursePlanning coursePlanning = null;
            using (var session = _repository.CreateSession())
            {
                var dbEntity = await session.GetByCourseIdAsync(courseId);
                if (dbEntity != null)
                    coursePlanning = _mapper.ToEntity(dbEntity);
            }

            return coursePlanning;
        }

        public override async Task<CoursePlanning> SaveAsync(CoursePlanning entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var prevId = Guid.Parse(entity.Id.ToString());
            var saved = await base.SaveAsync(entity);
            if (prevId == Guid.Empty)
            {
                return saved;
            }

            await DeleteAsync(prevId);

            using (var lessonSession = _lessonRepository.CreateSession())
            using (var examinationEventSession = _examinationEventRepository.CreateSession())
            {
                var lessons = await lessonSession.GetByCoursePlanningIdAsync(prevId);
                var examinationEvents = await examinationEventSession.GetByCoursePlanningIdAsync(prevId);

                foreach (var lesson in lessons)
                {
                    await lessonSession.ChangeCoursePlanningIdAsync(lesson.Id, saved.Id);
                }

                foreach (var examinationEvent in examinationEvents)
                {
                    await examinationEventSession.ChangeCoursePlanningIdAsync(examinationEvent.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
