using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddTransient<IEntityMapper<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria>, AssessmentCriteriaMap>();
            services.AddTransient<IEntityMapper<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension>, AssessmentDimensionMap>();
            services.AddTransient<IEntityMapper<Domain.Competency, Persistency.Database.Domain.Competency>, CompetencyMap>();
            services.AddTransient<IEntityMapper<Domain.Course, Persistency.Database.Domain.Course>, CourseMap>();
            services.AddTransient<IEntityMapper<Domain.CoursePlanning, Persistency.Database.Domain.CoursePlanning>, CoursePlanningMap>();
            services.AddTransient<IEntityMapper<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent>, ExaminationEventMap>();
            services.AddTransient<IEntityMapper<Domain.Exam, Persistency.Database.Domain.Exam>, ExamMap>();
            services.AddTransient<IEntityMapper<Domain.GradeDescription, Persistency.Database.Domain.GradeDescription>, GradeDescriptionMap>();
            services.AddTransient<IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome>, LearningOutcomeMap>();
            services.AddTransient<IEntityMapper<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit>, LearningOutcomeUnitMap>();
            services.AddTransient<IEntityMapper<Domain.Lesson, Persistency.Database.Domain.Lesson>, LessonMap>();
            services.AddTransient<IEntityMapper<Domain.User, Persistency.Database.Domain.User>, UserMap>();
            services.AddTransient<IEntityMapper<Domain.Study, Persistency.Database.Domain.Study>, StudyMap>();

            return services;
        }
    }
}
