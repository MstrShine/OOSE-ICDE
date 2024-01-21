namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class LearningOutcomeUnitMapTest : AbstractMapTest<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit>
    {
        protected override void SetupMapper()
        {
            _mapper = new LearningOutcomeUnitMap();
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
                Code = "Code",
                CTE = 5,
                MinimumGrade = 5,
                Name = "Name"
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.CourseId, converted.CourseId);
            Assert.AreEqual(entity.Code, converted.Code);
            Assert.AreEqual(entity.CTE, converted.CTE);
            Assert.AreEqual(entity.MinimumGrade, converted.MinimumGrade);
            Assert.AreEqual(entity.Name, converted.Name);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
                Code = "Code",
                CTE = 5,
                MinimumGrade = 5,
                Name = "Name"
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.CourseId, converted.CourseId);
            Assert.AreEqual(dbEntity.Code, converted.Code);
            Assert.AreEqual(dbEntity.CTE, converted.CTE);
            Assert.AreEqual(dbEntity.MinimumGrade, converted.MinimumGrade);
            Assert.AreEqual(dbEntity.Name, converted.Name);
        }
    }
}
