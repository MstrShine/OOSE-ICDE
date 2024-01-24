using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class LearningOutcomeValidation : AbstractEntityValidation<LearningOutcome, ILearningOutcomeManager>
    {
        private readonly ILessonManager _lessonManager;

        public LearningOutcomeValidation(
            ILearningOutcomeManager entityManager,
            ILessonManager lessonManager) : base(entityManager)
        {
            _lessonManager = lessonManager;
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var learningOutcome = await _entityManager.GetByIdAsync(entityId);
            if (learningOutcome == null)
            {
                return false;
            }

            if (!learningOutcome.IsValid())
            {
                return false;
            }

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            var lessons = await _lessonManager.GetByLearningOutcomeIdAsync(parentId);
            if (lessons.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
