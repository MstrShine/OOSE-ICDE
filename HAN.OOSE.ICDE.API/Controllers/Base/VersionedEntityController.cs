using HAN.OOSE.ICDE.API.Interfaces;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers.Base
{
    public abstract class VersionedEntityController<T> : BaseEntityController<T>, IVersionedEntityController<T> where T : VersionedEntity
    {
        protected readonly IVersionedEntityManager<T> _entityManager;

        protected VersionedEntityController(
            ILogger<BaseEntityController<T>> logger,
            IVersionedEntityManager<T> entityManager) : base(logger)
        {
            _entityManager = entityManager;
        }

        public abstract Task<ActionResult> Delete(Guid id);
        public abstract Task<ActionResult<T>> Get(Guid id);
        public abstract Task<ActionResult<List<T>>> GetAll();
        public abstract Task<ActionResult<List<T>>> GetByVersionId(Guid versionId);
        public abstract Task<ActionResult<T>> Post(T entity);
        public abstract Task<ActionResult<T>> Put(Guid id, T entity);
    }
}
