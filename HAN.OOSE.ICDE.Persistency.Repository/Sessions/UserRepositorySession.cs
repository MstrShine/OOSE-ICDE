using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class UserRepositorySession : IUserRepositorySession
    {
        private bool disposedValue;

        private readonly DataContext _dataContext;

        private DbSet<User> Table => _dataContext.Users;

        public UserRepositorySession(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var user = await Table.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"Could not find User with id: {id}");
            }

            user.IsDeleted = true;
            Table.Update(user);

            await _dataContext.SaveChangesAsync();
        }

        public Task<List<User>> GetAllAsync()
        {
            return Table.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return Table.SingleOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return Table.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> SaveAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            await Table.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
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

            Table.Update(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
