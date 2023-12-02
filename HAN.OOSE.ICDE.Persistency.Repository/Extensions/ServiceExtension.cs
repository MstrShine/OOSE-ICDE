using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
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
            services.AddTransient<IVersionedEntityRepository<AssessmentCriteria>, AssessmentCriteriaRepository>();
            services.AddTransient<IVersionedEntityRepository<AssessmentDimension>, AssessmentDimensionRepository>();
            services.AddTransient<IVersionedEntityRepository<Competency>, CompetencyRepository>();
            services.AddTransient<IVersionedEntityRepository<CoursePlanning>, CoursePlanningRepository>();
            services.AddTransient<IVersionedEntityRepository<Course>, CourseRepository>();
            services.AddTransient<IVersionedEntityRepository<ExaminationEvent>, ExaminationEventRepository>();
            services.AddTransient<IVersionedEntityRepository<Exam>, ExamRepository>();
            services.AddTransient<IVersionedEntityRepository<GradeDescription>, GradeDescriptionRepository>();
            services.AddTransient<IVersionedEntityRepository<LearningOutcome>, LearningOutcomeRepository>();
            services.AddTransient<IVersionedEntityRepository<LearningOutcomeUnit>, LearningOutcomeUnitRepository>();
            services.AddTransient<IVersionedEntityRepository<Lesson>, LessonRepository>();

            services.AddTransient<IEntityRepository<User>, UserRepository>();

            return services;
        }
    }
}
