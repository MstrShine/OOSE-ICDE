using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class ExamValidation : AbstractEntityValidation<Exam, IExamManager>
    {
        private readonly IExaminationEventManager _examinationEventManager;

        private readonly IAssessmentDimensionManager _assessmentDimensionManager;
        private readonly IEntityValidation<AssessmentDimension> _assessmentDimensionValidation;

        private readonly IAssessmentCriteriaManager _assessmentCriteriaManager;

        public ExamValidation(
            IExamManager entityManager,
            IExaminationEventManager examinationEventManager,
            IAssessmentDimensionManager assessmentDimensionManager,
            IEntityValidation<AssessmentDimension> assessmentDimensionValidation,
            IAssessmentCriteriaManager assessmentCriteriaManager) : base(entityManager)
        {
            _examinationEventManager = examinationEventManager;
            _assessmentDimensionManager = assessmentDimensionManager;
            _assessmentDimensionValidation = assessmentDimensionValidation;
            _assessmentCriteriaManager = assessmentCriteriaManager;
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var exam = await _entityManager.GetByIdAsync(entityId);
            if (exam == null)
            {
                return false;
            }

            if (!exam.IsValid())
            {
                return false;
            }

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            var assessmentDimensions = await _assessmentDimensionManager.GetByExamIdAsync(parentId);
            if (assessmentDimensions.Count == 0)
            {
                return false;
            }

            var totalWeightOfDimensions = 0;
            foreach (var assessmentDimension in assessmentDimensions)
            {
                var valid = await _assessmentDimensionValidation.ValidateEntity(assessmentDimension.Id);
                if (!valid)
                {
                    return false;
                }

                var assessmentCriterias = await _assessmentCriteriaManager.GetByAssessmentDimensionIdAsync(assessmentDimension.Id);
                totalWeightOfDimensions += assessmentCriterias.Sum(x => x.Weight) ?? 0;
            }

            if (totalWeightOfDimensions != 100)
            {
                return false;
            }

            var examinationEvents = await _examinationEventManager.GetByExamIdAsync(parentId);
            if (examinationEvents.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
