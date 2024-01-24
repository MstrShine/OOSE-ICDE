using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Validation.Base
{
    public abstract class AbstractEntityValidation<T, Y> : IEntityValidation<T> where T : Entity where Y : IEntityManager<T>
    {
        protected readonly Y _entityManager;

        public AbstractEntityValidation(Y entityManager)
        {
            _entityManager = entityManager;
        }

        public abstract Task<bool> ValidateEntity(Guid entityId);

        protected abstract Task<bool> ValidateChildren(Guid parentId);
    }
}
