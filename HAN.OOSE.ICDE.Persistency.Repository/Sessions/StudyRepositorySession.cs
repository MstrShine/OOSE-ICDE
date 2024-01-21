using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class StudyRepositorySession : IEntityRepositorySession<Study>
    {
        private bool disposedValue;

        private readonly DataContext _dataContext;

        private DbSet<Study> Table => _dataContext.Studies;

        public StudyRepositorySession(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var study = new Study { Id = id };
            Table.Remove(study);

            await _dataContext.SaveChangesAsync();
        }

        public Task<List<Study>> GetAllAsync()
        {
            return Table.ToListAsync();
        }

        public Task<Study> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return Table.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Study> SaveAsync(Study entity)
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
        // ~StudyRepositorySession()
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
