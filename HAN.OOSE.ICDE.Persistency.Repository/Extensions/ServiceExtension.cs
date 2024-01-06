using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<IAssessmentCriteriaRepositorySession, AssessmentCriteria>, AssessmentCriteriaRepository>();
            services.AddTransient<IAssessmentCriteriaRepositorySession, AssessmentCriteriaRepositorySession>();

            services.AddScoped<IEntityRepository<IAssessmentDimensionRepositorySession, AssessmentDimension>, AssessmentDimensionRepository>();
            services.AddTransient<IAssessmentDimensionRepositorySession, AssessmentDimensionRepositorySession>();

            services.AddScoped<IEntityRepository<ICompetencyRepositorySession, Competency>, CompetencyRepository>();
            services.AddTransient<ICompetencyRepositorySession, CompetencyRepositorySession>();

            services.AddScoped<IEntityRepository<ICoursePlanningRepositorySession, CoursePlanning>, CoursePlanningRepository>();
            services.AddTransient<ICoursePlanningRepositorySession, CoursePlanningRepositorySession>();

            services.AddScoped<IEntityRepository<ICourseRepositorySession, Course>, CourseRepository>();
            services.AddTransient<ICourseRepositorySession, CourseRepositorySession>();

            services.AddScoped<IEntityRepository<IExaminationEventRepositorySession, ExaminationEvent>, ExaminationEventRepository>();
            services.AddTransient<IExaminationEventRepositorySession, ExaminationEventRepositorySession>();

            services.AddScoped<IEntityRepository<IExamRepositorySession, Exam>, ExamRepository>();
            services.AddTransient<IExamRepositorySession, ExamRepositorySession>();

            services.AddScoped<IEntityRepository<IGradeDescriptionRepositorySession, GradeDescription>, GradeDescriptionRepository>();
            services.AddTransient<IGradeDescriptionRepositorySession, GradeDescriptionRepositorySession>();
            
            services.AddScoped<IEntityRepository<ILearningOutcomeRepositorySession, LearningOutcome>, LearningOutcomeRepository>();
            services.AddTransient<ILearningOutcomeRepositorySession, LearningOutcomeRepositorySession>();

            services.AddScoped<IEntityRepository<ILearningOutcomeUnitRepositorySession, LearningOutcomeUnit>, LearningOutcomeUnitRepository>();
            services.AddTransient<ILearningOutcomeUnitRepositorySession, LearningOutcomeUnitRepositorySession>();

            services.AddScoped<IEntityRepository<ILessonRepositorySession, Lesson>, LessonRepository>();
            services.AddTransient<ILessonRepositorySession, LessonRepositorySession>();

            services.AddScoped<IEntityRepository<IUserRepositorySession, User>, UserRepository>();
            services.AddTransient<IUserRepositorySession, UserRepositorySession>();

            services.AddScoped<IEntityRepository<IEntityRepositorySession<Study>, Study>, StudyRepository>();
            services.AddTransient<IEntityRepositorySession<Study>, StudyRepositorySession>();

            return services;
        }
    }
}
