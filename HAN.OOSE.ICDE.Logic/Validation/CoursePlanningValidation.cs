using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class CoursePlanningValidation : AbstractEntityValidation<CoursePlanning, ICoursePlanningManager>
    {
        private readonly ILessonManager _lessonManager;
        private readonly IEntityValidation<Lesson> _lessonValidation;

        private readonly IExaminationEventManager _examinationEventManager;
        private readonly IEntityValidation<ExaminationEvent> _examinationEventValidation;

        public CoursePlanningValidation(
            ICoursePlanningManager entityManager,
            ILessonManager lessonManager,
            IEntityValidation<Lesson> lessonValidation,
            IExaminationEventManager examinationEventManager,
            IEntityValidation<ExaminationEvent> examinationEventValidation) : base(entityManager)
        {
            _lessonManager = lessonManager;
            _lessonValidation = lessonValidation;
            _examinationEventManager = examinationEventManager;
            _examinationEventValidation = examinationEventValidation;
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var coursePlanning = await _entityManager.GetByIdAsync(entityId);
            if (coursePlanning == null)
            {
                return false;
            }

            if (!coursePlanning.IsValid())
            {
                return false;
            }

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            var lessons = await _lessonManager.GetByCoursePlanningIdAsync(parentId);
            if (lessons.Count == 0)
            {
                return false;
            }

            foreach (var lesson in lessons)
            {
                var valid = await _lessonValidation.ValidateEntity(lesson.Id);
                if (!valid)
                {
                    return false;
                }
            }

            var examinationEvents = await _examinationEventManager.GetByCoursePlanningIdAsync(parentId);
            if (examinationEvents.Count == 0)
            {
                return false;
            }

            foreach (var examEvent in examinationEvents)
            {
                var valid = await _examinationEventValidation.ValidateEntity(examEvent.Id);
                if (!valid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
