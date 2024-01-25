using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class StudyManager : IEntityManager<Study>
    {
        private readonly IEntityMapper<Study, Persistency.Database.Domain.Study> _mapper;
        private readonly IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.Study>, Persistency.Database.Domain.Study> _repository;

        public StudyManager(
            IEntityMapper<Study, Persistency.Database.Domain.Study> mapper,
            IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.Study>, Persistency.Database.Domain.Study> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using (var session = _repository.CreateSession())
            {
                await session.DeleteAsync(id);
            }
        }

        public async Task<List<Study>> GetAllAsync()
        {
            var list = new List<Study>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetAllAsync();
                if (dbList != null && dbList.Count > 0)
                {
                    list = dbList.Select(x => _mapper.ToEntity(x)).ToList();
                }
            }

            return list;
        }

        public async Task<Study> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Study study = null;
            using (var session = _repository.CreateSession())
            {
                var dbEntity = await session.GetByIdAsync(id);
                if (dbEntity != null)
                {
                    study = _mapper.ToEntity(dbEntity);
                }
            }

            return study;
        }

        public async Task<Study> SaveAsync(Study entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Study saved = null;
            using (var session = _repository.CreateSession())
            {
                var converted = _mapper.FromEntity(entity);
                var fromDb = await session.SaveAsync(converted);
                if (fromDb != null)
                {
                    saved = _mapper.ToEntity(fromDb);
                }
            }

            return saved;
        }

        public async Task<Study> UpdateAsync(Study entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(entity.Id));
            }

            Study updated = null;
            using (var session = _repository.CreateSession())
            {
                var converted = _mapper.FromEntity(entity);
                var fromDb = await session.UpdateAsync(converted);
                if (fromDb != null)
                {
                    updated = _mapper.ToEntity(fromDb);
                }
            }

            return updated;
        }
    }
}
