using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class LessonValidation : AbstractEntityValidation<Lesson, ILessonManager>
    {
        public LessonValidation(ILessonManager entityManager) : base(entityManager)
        {
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var lesson = await _entityManager.GetByIdAsync(entityId);
            if (lesson == null)
            {
                return false;
            }

            if (!lesson.IsValid())
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
