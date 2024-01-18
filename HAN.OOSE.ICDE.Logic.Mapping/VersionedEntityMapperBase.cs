using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public abstract class VersionedEntityMapperBase<T, Y> : IEntityMapper<T, Y> where T : VersionedEntity, new() where Y : VersionDBEntity, new()
    {
        public VersionedEntityMapperBase()
        {
        }

        public Y FromEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var dbEntity = new Y()
            {
                Id = entity.Id,
                VersionCollection = entity.VersionCollection,
                DateOfCreation = entity.DateOfCreation,
                Author = entity.Author
            };

            return _FromEntity(dbEntity, entity);
        }

        public T ToEntity(Y dbEntity)
        {
            if (dbEntity == null)
            {
                throw new ArgumentNullException(nameof(dbEntity));
            }

            var entity = new T()
            {
                Id = dbEntity.Id,
                VersionCollection = dbEntity.VersionCollection,
                DateOfCreation = dbEntity.DateOfCreation,
                Author = dbEntity.Author
            };

            return _ToEntity(entity, dbEntity);
        }

        protected abstract Y _FromEntity(Y dbEntity, T entity);

        protected abstract T _ToEntity(T entity, Y dbEntity);
    }
}
