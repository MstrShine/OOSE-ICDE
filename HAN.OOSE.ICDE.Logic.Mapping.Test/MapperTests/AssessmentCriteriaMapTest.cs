namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class AssessmentCriteriaMapTest : AbstractMapTest<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria>
    {
        protected override void _EntityToDbEntity_Valid()
        {
            var entity = new Domain.AssessmentCriteria()
            {
                Id = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                AssessmentDimensionId = Guid.NewGuid(),
                Explanation = "Explanation",
                MinimumGrade = 5,
                Name = "name",
                Weight = 10
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.AssessmentDimensionId, converted.AssessmentDimensionId);
            Assert.AreEqual(entity.Explanation, converted.Explanation);
            Assert.AreEqual(entity.MinimumGrade, converted.MinimumGrade);
            Assert.AreEqual(entity.Name, converted.Name);
            Assert.AreEqual(entity.Weight, converted.Weight);
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.AssessmentCriteria()
            {
                Id = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                AssessmentDimensionId = Guid.NewGuid(),
                Explanation = "Explanation",
                MinimumGrade = 5,
                Name = "name",
                Weight = 10
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.AssessmentDimensionId, converted.AssessmentDimensionId);
            Assert.AreEqual(dbEntity.Explanation, converted.Explanation);
            Assert.AreEqual(dbEntity.MinimumGrade, converted.MinimumGrade);
            Assert.AreEqual(dbEntity.Name, converted.Name);
            Assert.AreEqual(dbEntity.Weight, converted.Weight);
        }

        protected override void SetupMapper()
        {
            _mapper = new AssessmentCriteriaMap();
        }
    }
}
