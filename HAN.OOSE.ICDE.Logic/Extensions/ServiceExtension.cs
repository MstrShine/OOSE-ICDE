﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
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
    }
}
