namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class LearningOutcomeMapTest : AbstractMapTest<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome>
    {
        protected override void SetupMapper()
        {
            _mapper = new LearningOutcomeMap();
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.LearningOutcome()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                LearningOutcomeUnitId = Guid.NewGuid(),
                ExamId = Guid.NewGuid(),
                Description = "Description",
                Name = "Name",
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.LearningOutcomeUnitId, converted.LearningOutcomeUnitId);
            Assert.AreEqual(entity.ExamId, converted.ExamId);
            Assert.AreEqual(entity.Description, converted.Description);
            Assert.AreEqual(entity.Name, converted.Name);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.LearningOutcome()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                LearningOutcomeUnitId = Guid.NewGuid(),
                ExamId = Guid.NewGuid(),
                Description = "Description",
                Name = "Name",
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.LearningOutcomeUnitId, converted.LearningOutcomeUnitId);
            Assert.AreEqual(dbEntity.ExamId, converted.ExamId);
            Assert.AreEqual(dbEntity.Description, converted.Description);
            Assert.AreEqual(dbEntity.Name, converted.Name);
        }
    }
}
