namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class ExamMapTest : AbstractMapTest<Domain.Exam, Persistency.Database.Domain.Exam>
    {
        protected override void SetupMapper()
        {
            _mapper = new ExamMap();
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.Exam()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                LearningOutcomeUnitId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
                MinimumGrade = 5,
                Type = Domain.Enums.ExamType.Casus,
                Weight = 5
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.LearningOutcomeUnitId, converted.LearningOutcomeUnitId);
            Assert.AreEqual(entity.Name, converted.Name);
            Assert.AreEqual(entity.Code, converted.Code);
            Assert.AreEqual(entity.MinimumGrade, converted.MinimumGrade);
            Assert.AreEqual(entity.Type.ToString(), converted.Type.ToString());
            Assert.AreEqual(entity.Weight, converted.Weight);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.Exam()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                LearningOutcomeUnitId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
                MinimumGrade = 5,
                Type = Persistency.Database.Domain.Enums.ExamType.Casus,
                Weight = 5
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.LearningOutcomeUnitId, converted.LearningOutcomeUnitId);
            Assert.AreEqual(dbEntity.Name, converted.Name);
            Assert.AreEqual(dbEntity.Code, converted.Code);
            Assert.AreEqual(dbEntity.MinimumGrade, converted.MinimumGrade);
            Assert.AreEqual(dbEntity.Type.ToString(), converted.Type.ToString());
            Assert.AreEqual(dbEntity.Weight, converted.Weight);
        }
    }
}
