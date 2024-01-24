using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class CompetencyValidation : AbstractEntityValidation<Competency, ICompetencyManager>
    {
        public CompetencyValidation(ICompetencyManager entityManager) : base(entityManager)
        {
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var competency = await _entityManager.GetByIdAsync(entityId);
            if (competency == null)
            {
                return false;
            }

            if (!competency.IsValid())
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
