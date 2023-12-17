using HAN.OOSE.ICDE.API.Interfaces;
using HAN.OOSE.ICDE.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers.Base
{
    public abstract class BaseEntityController<T> : ControllerBase, IEntityController<T> where T : Entity
    {
        protected readonly ILogger<BaseEntityController<T>> _logger;

        public BaseEntityController(ILogger<BaseEntityController<T>> logger)
        {
            _logger = logger;
        }

        public abstract Task<ActionResult> Delete(Guid id);
        public abstract Task<ActionResult<T>> Get(Guid id);
        public abstract Task<ActionResult<List<T>>> GetAll();
        public abstract Task<ActionResult<T>> Post(T entity);
        public abstract Task<ActionResult<T>> Put(Guid id, T entity);
    }
}
