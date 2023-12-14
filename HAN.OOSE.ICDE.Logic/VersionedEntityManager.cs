using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic
{
    public abstract class VersionedEntityManager<T, Y> : IVersionedEntityManager<T> where T : VersionedEntity where Y : VersionDBEntity
    {
        protected IEntityRepository<IVersionedEntityRepositorySession<Y>, Y> _repository;

        protected IEntityMapper<T, Y> _mapper;

        public VersionedEntityManager(
            IEntityRepository<IVersionedEntityRepositorySession<Y>, Y> repository,
            IEntityMapper<T, Y> mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using(var session = _repository.CreateSession())
            {
                await session.DeleteAsync(id);
            }
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var list = new List<T>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetAllAsync();
                if(dbList != null && dbList.Count > 0)
                {
                    list = dbList.Select(x => _mapper.ToEntity(x)).ToList();
                }
            }

            return list;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            T versionedEntity = null;
            using(var session = _repository.CreateSession())
            {
                var dbEntity = await session.GetByIdAsync(id);
                if(dbEntity != null)
                {
                    versionedEntity = _mapper.ToEntity(dbEntity);
                }
            }

            return versionedEntity;
        }

        public virtual async Task<List<T>> GetByVersionIdAsync(Guid versionId)
        {
            if(versionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(versionId));
            }

            var list = new List<T>();
            using(var session = _repository.CreateSession()) 
            { 
                var dbList = await session.GetByVersionIdAsync(versionId);
                if(dbList != null && dbList.Count > 0)
                {
                    list = dbList.Select(x => _mapper.ToEntity(x)).ToList();
                }
            }

            return list;
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            T saved = null;
            using(var session = _repository.CreateSession())
            {
                var converted = _mapper.FromEntity(entity);
                var fromDb = await session.SaveAsync(converted);
                if(fromDb != null)
                {
                    saved = _mapper.ToEntity(fromDb);
                }
            }

            return saved;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if(entity.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(entity.Id));
            }

            if(entity.VersionCollection == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(entity.VersionCollection));
            }

            T updated = null;
            using (var session = _repository.CreateSession())
            {
                var converted = _mapper.FromEntity(entity);
                var fromDb = await session.UpdateAsync(converted);
                if(fromDb != null)
                {
                    updated = _mapper.ToEntity(fromDb);
                }
            }

            return updated;
        }
    }
}
