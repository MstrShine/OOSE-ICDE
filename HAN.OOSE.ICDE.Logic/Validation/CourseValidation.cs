using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class CourseValidation : AbstractEntityValidation<Course, ICourseManager>
    {
        private readonly ICoursePlanningManager _coursePlanningManager;
        private readonly IEntityValidation<CoursePlanning> _coursePlanningValidation;

        private readonly ILearningOutcomeUnitManager _learningOutcomeUnitManager;
        private readonly IEntityValidation<LearningOutcomeUnit> _learningOutcomeUnitValidation;

        private readonly ICompetencyManager _competencyManager;
        private readonly IEntityValidation<Competency> _competencyValidation;

        private int CourseCTE = 0;

        public CourseValidation(
            ICourseManager entityManager, 
            ICoursePlanningManager coursePlanningManager, 
            IEntityValidation<CoursePlanning> coursePlanningValidation, 
            ILearningOutcomeUnitManager learningOutcomeUnitManager, 
            IEntityValidation<LearningOutcomeUnit> learningOutcomeUnitValidation, 
            ICompetencyManager competencyManager,
            IEntityValidation<Competency> competencyValidation) : base(entityManager)
        {
            _coursePlanningManager = coursePlanningManager;
            _coursePlanningValidation = coursePlanningValidation;
            _learningOutcomeUnitManager = learningOutcomeUnitManager;
            _learningOutcomeUnitValidation = learningOutcomeUnitValidation;
            _competencyManager = competencyManager;
            _competencyValidation = competencyValidation;
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var course = await _entityManager.GetByIdAsync(entityId);
            if (course == null)
            {
                return false;
            }
            if (!course.IsValid())
            {
                return false;
            }

            CourseCTE = course.CTE!.Value;

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            var coursePlanning = await _coursePlanningManager.GetByCourseIdAsync(parentId);
            var coursePlanningValid = await _coursePlanningValidation.ValidateEntity(coursePlanning.Id);
            if (!coursePlanningValid)
            {
                return false;
            }

            var learningOutcomeUnits = await _learningOutcomeUnitManager.GetByCourseIdAsync(parentId);
            var CteSum = learningOutcomeUnits.Sum(x => x.CTE);
            if (CteSum == null || CourseCTE != Math.Round(CteSum.Value)) 
            {
                return false;    
            }

            foreach(var learningOutcomeUnit in learningOutcomeUnits)
            {
                var learningOutcomeUnitValid = await _learningOutcomeUnitValidation.ValidateEntity(learningOutcomeUnit.Id);
                if (!learningOutcomeUnitValid)
                {
                    return false;
                }
            }

            var competencies = await _competencyManager.GetByCourseIdAsync(parentId);
            foreach(var competency in competencies)
            {
                var competencyValid = await _competencyValidation.ValidateEntity(competency.Id);
                if (!competencyValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
