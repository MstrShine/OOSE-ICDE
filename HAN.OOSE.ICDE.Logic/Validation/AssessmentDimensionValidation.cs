using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class AssessmentDimensionValidation : AbstractEntityValidation<AssessmentDimension, IAssessmentDimensionManager>
    {
        private readonly IAssessmentCriteriaManager _assessmentCriteriaManager;
        private readonly IEntityValidation<AssessmentCriteria> _assessmentCriteriaValidation;

        public AssessmentDimensionValidation(
            IAssessmentDimensionManager entityManager,
            IAssessmentCriteriaManager assessmentCriteriaManager,
            IEntityValidation<AssessmentCriteria> assessmentCriteriaValidation) : base(entityManager)
        {
            _assessmentCriteriaManager = assessmentCriteriaManager;
            _assessmentCriteriaValidation = assessmentCriteriaValidation;
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var assessmentDimension = await _entityManager.GetByIdAsync(entityId);

            if (assessmentDimension == null)
            {
                return false;
            }

            if (!assessmentDimension.IsValid())
            {
                return false;
            }

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            var assessmentCriterias = await _assessmentCriteriaManager.GetByAssessmentDimensionIdAsync(parentId);
            if (assessmentCriterias.Count == 0)
            {
                return false;
            }

            foreach (var criteria in assessmentCriterias)
            {
                var valid = await _assessmentCriteriaValidation.ValidateEntity(criteria.Id);
                if (!valid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
