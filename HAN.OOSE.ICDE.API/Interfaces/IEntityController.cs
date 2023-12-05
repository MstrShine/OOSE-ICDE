using HAN.OOSE.ICDE.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Interfaces
{
    public interface IEntityController<T> where T : Entity
    {
        Task<ActionResult<T>> Get(Guid id);

        Task<ActionResult<List<T>>> GetAll();

        Task<ActionResult<T>> Post(T entity);

        Task<ActionResult<T>> Put(Guid id, T entity);

        Task<ActionResult> Delete(Guid id);
    }
}
