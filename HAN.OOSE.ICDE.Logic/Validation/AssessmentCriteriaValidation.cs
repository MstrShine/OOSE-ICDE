using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Validation.Base;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class AssessmentCriteriaValidation : AbstractEntityValidation<AssessmentCriteria, IAssessmentCriteriaManager>
    {
        private readonly IGradeDescriptionManager _gradeDescriptionManager;
        private readonly IEntityValidation<GradeDescription> _gradeDescriptionValidation;

        private int assessmentCriteriaMinimumGrade = 0;

        public AssessmentCriteriaValidation(
            IAssessmentCriteriaManager entityManager,
            IGradeDescriptionManager gradeDescriptionManager,
            IEntityValidation<GradeDescription> gradeDescriptionValidation) : base(entityManager)
        {
            _gradeDescriptionManager = gradeDescriptionManager;
            _gradeDescriptionValidation = gradeDescriptionValidation;
        }

        public override async Task<bool> ValidateEntity(Guid entityId)
        {
            var assessmentCriteria = await _entityManager.GetByIdAsync(entityId);
            if (assessmentCriteria == null)
            {
                return false;
            }
            if (!assessmentCriteria.IsValid())
            {
                return false;
            }

            assessmentCriteriaMinimumGrade = assessmentCriteria.MinimumGrade.Value;

            return await ValidateChildren(entityId);
        }

        protected override async Task<bool> ValidateChildren(Guid parentId)
        {
            var gradeDescriptions = await _gradeDescriptionManager.GetByAssessmentCriteriaIdAsync(parentId);
            if (gradeDescriptions.Count < 2)
            {
                return false;
            }

            var allGrades = new Dictionary<int, int>(); // Grade, count
            foreach (var gradeDescription in gradeDescriptions)
            {
                if (allGrades.ContainsKey(gradeDescription.Grade.Value))
                {
                    allGrades[gradeDescription.Grade.Value]++;
                }
                else
                {
                    allGrades.Add(gradeDescription.Grade.Value, 1);
                }

                var valid = await _gradeDescriptionValidation.ValidateEntity(gradeDescription.Id);
                if (!valid)
                {
                    return false;
                }
            }

            if (allGrades.Values.Any(x => x > 1))
            {
                return false;
            }

            if (!allGrades.ContainsKey(assessmentCriteriaMinimumGrade))
            {
                return false;
            }

            return true;
        }
    }
}
