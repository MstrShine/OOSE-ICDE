using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Validation;
using HAN.OOSE.ICDE.Logic.Managers;
using HAN.OOSE.ICDE.Logic.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace HAN.OOSE.ICDE.Logic.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<IAssessmentCriteriaManager, AssessmentCriteriaManager>();
            services.AddScoped<IAssessmentDimensionManager, AssessmentDimensionManager>();
            services.AddScoped<ICompetencyManager, CompetencyManager>();
            services.AddScoped<ICourseManager, CourseManager>();
            services.AddScoped<ICoursePlanningManager, CoursePlanningManager>();
            services.AddScoped<IExaminationEventManager, ExaminationEventManager>();
            services.AddScoped<IExamManager, ExamManager>();
            services.AddScoped<IGradeDescriptionManager, GradeDescriptionManager>();
            services.AddScoped<ILearningOutcomeManager, LearningOutcomeManager>();
            services.AddScoped<ILearningOutcomeUnitManager, LearningOutcomeUnitManager>();
            services.AddScoped<ILessonManager, LessonManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IEntityManager<Study>, StudyManager>();

            return services;
        }

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddScoped<ICourseValidation, CourseValidation>();

            return services;
        }
    }
}
