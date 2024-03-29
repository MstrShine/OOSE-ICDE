﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class CourseManager : VersionedEntityManager<Course, Persistency.Database.Domain.Course, ICourseRepositorySession>, ICourseManager
    {
        private readonly IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency> _competencyRepository;
        private readonly IEntityRepository<ICoursePlanningRepositorySession, Persistency.Database.Domain.CoursePlanning> _coursePlanningRepository;
        private readonly IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit> _learningOutcomeUnitRepository;

        public CourseManager(
            IEntityRepository<ICourseRepositorySession, Persistency.Database.Domain.Course> repository,
            IEntityMapper<Course, Persistency.Database.Domain.Course> mapper,
            IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency> competencyRepository,
            IEntityRepository<ICoursePlanningRepositorySession, Persistency.Database.Domain.CoursePlanning> coursePlanningRepository,
            IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit> learningOutcomeUnitRepository) : base(repository, mapper)
        {
            _competencyRepository = competencyRepository;
            _coursePlanningRepository = coursePlanningRepository;
            _learningOutcomeUnitRepository = learningOutcomeUnitRepository;
        }

        public async Task<List<Course>> GetByStudyIdAsync(Guid studyId)
        {
            if (studyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studyId));
            }

            var courses = new List<Course>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByStudyIdAsync(studyId);
                courses = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return courses;
        }

        public override async Task<Course> SaveAsync(Course entity)
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

            using (var competencySession = _competencyRepository.CreateSession())
            using (var learningOutcomeUnitSession = _learningOutcomeUnitRepository.CreateSession())
            using (var coursePlanningSession = _coursePlanningRepository.CreateSession())
            {
                var competencies = await competencySession.GetByCourseIdAsync(prevId);
                var learningOutcomeUnits = await learningOutcomeUnitSession.GetByCourseIdAsync(prevId);
                var coursePlanning = await coursePlanningSession.GetByCourseIdAsync(prevId);

                foreach (var competency in competencies)
                {
                    await competencySession.ChangeCourseIdAsync(competency.Id, saved.Id);
                }

                foreach (var learningOutcomeUnit in learningOutcomeUnits)
                {
                    await learningOutcomeUnitSession.ChangeCourseIdAsync(learningOutcomeUnit.Id, saved.Id);
                }

                if (coursePlanning != null)
                {
                    await coursePlanningSession.ChangeCourseIdAsync(coursePlanning.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
