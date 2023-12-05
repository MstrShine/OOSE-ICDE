using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class AssessmentCriteriaMap : VersionedEntityMapperBase<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria>
    {
        private readonly IEntityMapper<Domain.GradeDescription, Persistency.Database.Domain.GradeDescription> _gradeDescriptionMap;

        public AssessmentCriteriaMap(
            IEntityMapper<Domain.User, Persistency.Database.Domain.User> userMap,
            IEntityMapper<Domain.GradeDescription, Persistency.Database.Domain.GradeDescription> gradeDescriptionMap) : base(userMap)
        {
            _gradeDescriptionMap = gradeDescriptionMap;
        }

        protected override Persistency.Database.Domain.AssessmentCriteria _FromEntity(Persistency.Database.Domain.AssessmentCriteria dbEntity, Domain.AssessmentCriteria entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Weight = entity.Weight;
            dbEntity.MinimumGrade = entity.MinimumGrade;
            dbEntity.GradeDescriptions = entity.GradeDescriptions.Select(x => _gradeDescriptionMap.FromEntity(x)).ToList();
            dbEntity.Explanation = entity.Explanation;

            return dbEntity;
        }

        protected override Domain.AssessmentCriteria _ToEntity(Domain.AssessmentCriteria entity, Persistency.Database.Domain.AssessmentCriteria dbEntity)
        {
            entity.Name = dbEntity.Name;
            entity.Weight = dbEntity.Weight;
            entity.MinimumGrade = dbEntity.MinimumGrade;
            entity.GradeDescriptions = dbEntity.GradeDescriptions.Select(x => _gradeDescriptionMap.ToEntity(x)).ToList();
            entity.Explanation = dbEntity.Explanation;

            return entity;
        }
    }
}
