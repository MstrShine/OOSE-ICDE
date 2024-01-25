using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Logic.Interfaces.Validation
{
    public interface IEntityValidation<T> where T : Entity
    {
        Task<bool> ValidateEntity(Guid entityId);
    }
}
