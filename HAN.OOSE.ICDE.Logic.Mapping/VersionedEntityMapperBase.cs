using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public abstract class VersionedEntityMapperBase<T, Y> : IEntityMapper<T, Y> where T : VersionedEntity, new() where Y : VersionDBEntity, new()
    {
        private readonly IEntityMapper<Domain.User, Persistency.Database.Domain.User> _userMap;

        public VersionedEntityMapperBase(IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap)
        {
            _userMap = userMap;
        }

        public Y FromEntity(T entity)
        {
            var dbEntity = new Y()
            {
                Id = entity.Id,
                VersionCollection = entity.VersionCollection,
                DateOfCreation = entity.DateOfCreation,
                Author = _userMap.FromEntity(entity.Author)
            };

            return _FromEntity(dbEntity, entity);
        }

        public T ToEntity(Y dbEntity)
        {
            var entity = new T()
            {
                Id = dbEntity.Id,
                VersionCollection = dbEntity.VersionCollection,
                DateOfCreation = dbEntity.DateOfCreation,
                Author = _userMap.ToEntity(dbEntity.Author)
            };

            return _ToEntity(entity, dbEntity);
        }

        protected abstract Y _FromEntity(Y dbEntity, T entity);

        protected abstract T _ToEntity(T entity, Y dbEntity);
    }
}
