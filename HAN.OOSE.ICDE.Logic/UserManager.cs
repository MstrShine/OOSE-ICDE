

using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Logic
{
    public class UserManager : IEntityManager<Domain.User>
    {
        private readonly IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.User>, Persistency.Database.Domain.User> _repository;
        private readonly IEntityMapper<Domain.User, Persistency.Database.Domain.User> _mapper;

        public UserManager(
            IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.User>, Persistency.Database.Domain.User> repository,
            IEntityMapper<Domain.User, Persistency.Database.Domain.User> mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
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

        public async Task<List<User>> GetAllAsync()
        {
            var list = new List<User>();
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

        public async Task<User> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            User user = null;
            using (var session = _repository.CreateSession())
            {
                var dbEntity = await session.GetByIdAsync(id);
                if (dbEntity != null)
                {
                    user = _mapper.ToEntity(dbEntity);
                }
            }

            return user;
        }

        public async Task<User> SaveAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            User saved = null;
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

        public async Task<User> UpdateAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(entity.Id));
            }

            User updated = null;
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
