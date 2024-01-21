using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base
{
    public abstract class VersionedRepositorySessionBase<T> : IVersionedEntityRepositorySession<T> where T : VersionedDBEntity, new()
    {
        protected readonly DataContext _DataContext;

        private bool _DisposedValue;

        protected abstract DbSet<T> Table { get; }

        protected readonly Type _Type = typeof(T);

        protected VersionedRepositorySessionBase(DataContext dataContext)
        {
            this._DataContext = dataContext;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = new T();
            entity.Id = id;
            Table.Remove(entity);

            await _DataContext.SaveChangesAsync();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return Table.ToListAsync();
        }

        public virtual Task<T> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return Table.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual Task<List<T>> GetByVersionIdAsync(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(versionId));
            }

            return Table.Where(x => x.VersionCollection == versionId).ToListAsync();
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            if (entity.VersionCollection == Guid.Empty)
            {
                entity.VersionCollection = Guid.NewGuid();
            }

            await Table.AddAsync(entity);
            await _DataContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(entity.Id));
            }

            if (entity.VersionCollection == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(entity.VersionCollection));
            }

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _DisposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~VersionedRepositoryBase()
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
