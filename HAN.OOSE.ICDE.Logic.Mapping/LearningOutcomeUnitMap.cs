using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class LearningOutcomeUnitMap : VersionedEntityMapperBase<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit>
    {
        private readonly IEntityMapper<Domain.Exam, Persistency.Database.Domain.Exam> _examMap;
        private readonly IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> _learningOutcomeMap;
        private readonly IEntityMapper<Domain.Competency, Persistency.Database.Domain.Competency> _competencyMap;

        public LearningOutcomeUnitMap(
            IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap,
            IEntityMapper<Domain.Exam, Persistency.Database.Domain.Exam> examMap,
            IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> learningOutcomeMap,
            IEntityMapper<Domain.Competency, Persistency.Database.Domain.Competency> competencyMap) : base(userMap) 
        {
            _examMap = examMap;
            _learningOutcomeMap = learningOutcomeMap;
            _competencyMap = competencyMap;
        }

        protected override Persistency.Database.Domain.LearningOutcomeUnit _FromEntity(Persistency.Database.Domain.LearningOutcomeUnit dbEntity, Domain.LearningOutcomeUnit entity)
        {
            dbEntity.Code = entity.Code;
            dbEntity.CTE = entity.CTE;
            dbEntity.MinimumGrade = entity.MinimumGrade;
            dbEntity.Exams = entity.Exams.Select(x => _examMap.FromEntity(x)).ToList();
            dbEntity.LearningOutcomes = entity.LearningOutcomes.Select(x => _learningOutcomeMap.FromEntity(x)).ToList();
            dbEntity.Competencies = entity.Competencies.Select(x => _competencyMap.FromEntity(x)).ToList();

            return dbEntity;
        }

        protected override Domain.LearningOutcomeUnit _ToEntity(Domain.LearningOutcomeUnit entity, Persistency.Database.Domain.LearningOutcomeUnit dbEntity)
        {
            entity.Code = dbEntity.Code;
            entity.CTE = dbEntity.CTE;
            entity.MinimumGrade = dbEntity.MinimumGrade;
            entity.Exams = dbEntity.Exams.Select(x => _examMap.ToEntity(x)).ToList();
            entity.LearningOutcomes = dbEntity.LearningOutcomes.Select(x => _learningOutcomeMap.ToEntity(x)).ToList();
            entity.Competencies = dbEntity.Competencies.Select(x => _competencyMap.ToEntity(x)).ToList();

            return entity;
        }
    }
}
