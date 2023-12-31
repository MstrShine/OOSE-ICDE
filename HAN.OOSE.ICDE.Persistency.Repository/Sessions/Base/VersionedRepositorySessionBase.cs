﻿using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base
{
    public abstract class VersionedRepositorySessionBase<T> : IVersionedEntityRepositorySession<T> where T : VersionDBEntity, new()
    {
        protected readonly DataContext dataContext;

        private bool disposedValue;

        protected abstract DbSet<T> Table { get; }

        protected VersionedRepositorySessionBase(DataContext dataContext)
        {
            this.dataContext = dataContext;
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

            await dataContext.SaveChangesAsync();
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

            return Table.SingleAsync(x => x.Id == id);
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
            await dataContext.SaveChangesAsync();

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
            await dataContext.SaveChangesAsync();

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
