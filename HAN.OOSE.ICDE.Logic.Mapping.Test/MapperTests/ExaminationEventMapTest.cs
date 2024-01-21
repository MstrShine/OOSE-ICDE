namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class ExaminationEventMapTest : AbstractMapTest<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent>
    {
        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.ExaminationEvent()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                ExamId = Guid.NewGuid(),
                Date = DateTime.Now,
                Prerequisites = "Prerequisites",
                Type = "Type"
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.CoursePlanningId, converted.CoursePlanningId);
            Assert.AreEqual(entity.ExamId, converted.ExamId);
            Assert.AreEqual(entity.Date, converted.Date);
            Assert.AreEqual(entity.Prerequisites, converted.Prerequisites);
            Assert.AreEqual(entity.Type, converted.Type);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.ExaminationEvent()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                ExamId = Guid.NewGuid(),
                Date = DateTime.Now,
                Prerequisites = "Prerequisites",
                Type = "Type"
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.CoursePlanningId, converted.CoursePlanningId);
            Assert.AreEqual(dbEntity.ExamId, converted.ExamId);
            Assert.AreEqual(dbEntity.Date, converted.Date);
            Assert.AreEqual(dbEntity.Prerequisites, converted.Prerequisites);
            Assert.AreEqual(dbEntity.Type, converted.Type);
        }

        protected override void SetupMapper()
        {
            _mapper = new ExaminationEventMap();
        }
    }
}
