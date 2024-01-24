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

        public ExamValidation(
            IExamManager entityManager,
            IExaminationEventManager examinationEventManager,
            IAssessmentDimensionManager assessmentDimensionManager,
            IEntityValidation<AssessmentDimension> assessmentDimensionValidation) : base(entityManager)
        {
            _examinationEventManager = examinationEventManager;
            _assessmentDimensionManager = assessmentDimensionManager;
            _assessmentDimensionValidation = assessmentDimensionValidation;
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

            foreach (var assessmentDimension in assessmentDimensions)
            {
                var valid = await _assessmentDimensionValidation.ValidateEntity(assessmentDimension.Id);
                if (!valid)
                {
                    return false;
                }
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
