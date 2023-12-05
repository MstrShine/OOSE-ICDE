using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<IVersionedEntityManager<AssessmentCriteria>, AssessmentCriteriaManager>();
            services.AddScoped<IVersionedEntityManager<AssessmentDimension>, AssessmentDimensionManager>();
            services.AddScoped<IVersionedEntityManager<Competency>, CompetencyManager>();
            services.AddScoped<IVersionedEntityManager<Course>, CourseManager>();
            services.AddScoped<IVersionedEntityManager<CoursePlanning>, CoursePlanningManager>();
            services.AddScoped<IVersionedEntityManager<ExaminationEvent>, ExaminationEventManager>();
            services.AddScoped<IVersionedEntityManager<Exam>, ExamManager>();
            services.AddScoped<IVersionedEntityManager<GradeDescription>, GradeDescriptionManager>();
            services.AddScoped<IVersionedEntityManager<LearningOutcome>, LearningOutcomeManager>();
            services.AddScoped<IVersionedEntityManager<LearningOutcomeUnit>, LearningOutcomeUnitManager>();
            services.AddScoped<IVersionedEntityManager<Lesson>, LessonManager>();
            services.AddScoped<IEntityManager<User>, UserManager>();

            return services;
        }
    }
}
