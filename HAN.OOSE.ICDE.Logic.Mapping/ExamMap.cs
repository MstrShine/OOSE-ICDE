using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class ExamMap : VersionedEntityMapperBase<Domain.Exam, Persistency.Database.Domain.Exam>
    {
        private readonly IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> _learningOutcomeMap;
        private readonly IEntityMapper<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension> _assessmentDimensionMap;
        private readonly IEntityMapper<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent> _examinationEventMap;

        public ExamMap(
            IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap, 
            IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> learningOutcomeMap, 
            IEntityMapper<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension> assessmentDimensionMap, 
            IEntityMapper<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent> examinationEventMap) : base(userMap)
        {
            _learningOutcomeMap = learningOutcomeMap;
            _assessmentDimensionMap = assessmentDimensionMap;
            _examinationEventMap = examinationEventMap;
        }

        protected override Persistency.Database.Domain.Exam _FromEntity(Persistency.Database.Domain.Exam dbEntity, Domain.Exam entity)
        {
            dbEntity.Weight = entity.Weight;
            dbEntity.Type = entity.Type;
            dbEntity.MinimumGrade = entity.MinimumGrade;
            dbEntity.LearningOutcomes = entity.LearningOutcomes.Select(x => _learningOutcomeMap.FromEntity(x)).ToList();
            dbEntity.AssessmentDimensions = entity.AssessmentDimensions.Select(x => _assessmentDimensionMap.FromEntity(x)).ToList();
            dbEntity.ExaminationEvents = entity.ExaminationEvents.Select(x => _examinationEventMap.FromEntity(x)).ToList();

            return dbEntity;
        }

        protected override Domain.Exam _ToEntity(Domain.Exam entity, Persistency.Database.Domain.Exam dbEntity)
        {
            entity.Weight = dbEntity.Weight;
            entity.Type = dbEntity.Type;
            entity.MinimumGrade = dbEntity.MinimumGrade;
            entity.LearningOutcomes = dbEntity.LearningOutcomes.Select(x => _learningOutcomeMap.ToEntity(x)).ToList();
            entity.AssessmentDimensions = dbEntity.AssessmentDimensions.Select(x => _assessmentDimensionMap.ToEntity(x)).ToList();
            entity.ExaminationEvents = dbEntity.ExaminationEvents.Select(x => _examinationEventMap.ToEntity(x)).ToList();

            return entity;
        }
    }
}
