using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
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
            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<AssessmentCriteria>, AssessmentCriteria>, AssessmentCriteriaRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<AssessmentCriteria>, AssessmentCriteriaRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<AssessmentDimension>, AssessmentDimension>, AssessmentDimensionRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<AssessmentDimension>, AssessmentDimensionRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<Competency>, Competency>, CompetencyRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<Competency>, CompetencyRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<CoursePlanning>, CoursePlanning>, CoursePlanningRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<CoursePlanning>, CoursePlanningRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<Course>, Course>, CourseRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<Course>, CourseRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<ExaminationEvent>, ExaminationEvent>, ExaminationEventRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<ExaminationEvent>, ExaminationEventRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<Exam>, Exam>, ExamRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<Exam>, ExamRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<GradeDescription>, GradeDescription>, GradeDescriptionRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<GradeDescription>, GradeDescriptionRepositorySession>();
            
            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<LearningOutcome>, LearningOutcome>, LearningOutcomeRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<LearningOutcome>, LearningOutcomeRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<LearningOutcome>, LearningOutcome>, LearningOutcomeRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<LearningOutcomeUnit>, LearningOutcomeUnitRepositorySession>();

            services.AddScoped<IEntityRepository<IVersionedEntityRepositorySession<Lesson>, Lesson>, LessonRepository>();
            services.AddTransient<IVersionedEntityRepositorySession<Lesson>, LessonRepositorySession>();

            services.AddScoped<IEntityRepository<IEntityRepositorySession<User>, User>, UserRepository>();
            services.AddTransient<IEntityRepositorySession<User>, UserRepositorySession>();

            return services;
        }
    }
}
