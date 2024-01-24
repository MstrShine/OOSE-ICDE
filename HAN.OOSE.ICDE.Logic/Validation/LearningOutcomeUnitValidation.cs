using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class LearningOutcomeUnitValidation : AbstractEntityValidation<LearningOutcomeUnit, ILearningOutcomeUnitManager>
    {
        private readonly ILearningOutcomeManager _learningOutcomeManager;
        private readonly IEntityValidation<LearningOutcome> _learningOutcomeValidation;

        private readonly IExamManager _examManager;
        private readonly IEntityValidation<Exam> _examValidation;

        public LearningOutcomeUnitValidation(
            ILearningOutcomeUnitManager entityManager,
            ILearningOutcomeManager learningOutcomeManager,
            IEntityValidation<LearningOutcome> learningOutcomeValidation,
            IExamManager examManager,
            IEntityValidation<Exam> examValidation) : base(entityManager)
        {
            _learningOutcomeManager = learningOutcomeManager;
            _learningOutcomeValidation = learningOutcomeValidation;
            _examManager = examManager;
            _examValidation = examValidation;
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var learningOutcomeUnit = await _entityManager.GetByIdAsync(entityId);
            if (learningOutcomeUnit == null)
            {
                return false;
            }

            if (!learningOutcomeUnit.IsValid())
            {
                return false;
            }

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            var learningOutcomes = await _learningOutcomeManager.GetByLearningOutcomeUnitIdAsync(parentId);
            if (learningOutcomes.Count == 0)
            {
                return false;
            }

            foreach (var learningOutcome in learningOutcomes)
            {
                var valid = await _learningOutcomeValidation.ValidateEntity(learningOutcome.Id);
                if (!valid)
                {
                    return false;
                }
            }

            var exams = await _examManager.GetByLearningOutcomeUnitIdAsync(parentId);
            if (exams.Count == 0)
            {
                return false;
            }

            foreach (var exam in exams)
            {
                var valid = await _examValidation.ValidateEntity(exam.Id);
                if (!valid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
