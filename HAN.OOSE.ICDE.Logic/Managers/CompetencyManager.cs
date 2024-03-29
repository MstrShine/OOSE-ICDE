﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class CompetencyManager : VersionedEntityManager<Competency, Persistency.Database.Domain.Competency, ICompetencyRepositorySession>, ICompetencyManager
    {
        public CompetencyManager(
            IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency> repository,
            IEntityMapper<Competency, Persistency.Database.Domain.Competency> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<Competency>> GetByCourseIdAsync(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var competencies = new List<Competency>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByCourseIdAsync(courseId);
                competencies = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return competencies;
        }

        public async Task<List<Competency>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            var competencies = new List<Competency>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByLearningOutcomeUnitIdAsync(learningOutcomeUnitId);
                competencies = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return competencies;
        }

        public override async Task<Competency> SaveAsync(Competency entity)
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

            return saved;
        }
    }
}
