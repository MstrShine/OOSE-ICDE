using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Validation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override Task<bool> ValidateEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ValidateChildren(Guid parentId)
        {
            throw new NotImplementedException();
        }
    }
}
