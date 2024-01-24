using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class ExaminationEventValidation : AbstractEntityValidation<ExaminationEvent, IExaminationEventManager>
    {
        public ExaminationEventValidation(IExaminationEventManager entityManager) : base(entityManager)
        {
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var examinationEvent = await _entityManager.GetByIdAsync(entityId);
            if (examinationEvent == null)
            {
                return false;
            }

            if (!examinationEvent.IsValid())
            {
                return false;
            }

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            return true; // No children
        }
    }
}
