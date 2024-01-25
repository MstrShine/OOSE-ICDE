using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class GradeDescriptionValidation : AbstractEntityValidation<GradeDescription, IGradeDescriptionManager>
    {
        public GradeDescriptionValidation(IGradeDescriptionManager entityManager) : base(entityManager)
        {
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var gradeDescription = await _entityManager.GetByIdAsync(entityId);
            if (gradeDescription == null)
            {
                return false;
            }

            if (!gradeDescription.IsValid())
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
