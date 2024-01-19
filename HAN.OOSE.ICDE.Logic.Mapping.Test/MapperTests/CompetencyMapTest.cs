namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class CompetencyMapTest : AbstractMapTest<Domain.Competency, Persistency.Database.Domain.Competency>
    {
        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.Competency()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
                LearningOutcomeUnitId = Guid.NewGuid(),
                Code = "Code",
                Name = "Name"
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.CourseId, converted.CourseId);
            Assert.AreEqual(entity.LearningOutcomeUnitId, converted.LearningOutcomeUnitId);
            Assert.AreEqual(entity.Code, converted.Code);
            Assert.AreEqual(entity.Name, converted.Name);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.Competency()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
                LearningOutcomeUnitId = Guid.NewGuid(),
                Code = "Code",
                Name = "Name"
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.CourseId, converted.CourseId);
            Assert.AreEqual(dbEntity.LearningOutcomeUnitId, converted.LearningOutcomeUnitId);
            Assert.AreEqual(dbEntity.Code, converted.Code);
            Assert.AreEqual(dbEntity.Name, converted.Name);
        }

        protected override void SetupMapper()
        {
            _mapper = new CompetencyMap();
        }
    }
}
