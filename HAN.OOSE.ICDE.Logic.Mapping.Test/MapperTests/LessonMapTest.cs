namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class LessonMapTest : AbstractMapTest<Domain.Lesson, Persistency.Database.Domain.Lesson>
    {
        protected override void SetupMapper()
        {
            _mapper = new LessonMap();
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.Lesson()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Description",
                Didactics = "Didactics",
                Name = "Name"
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.CoursePlanningId, converted.CoursePlanningId);
            Assert.AreEqual(entity.Date, converted.Date);
            Assert.AreEqual(entity.Description, converted.Description);
            Assert.AreEqual(entity.Didactics, converted.Didactics);
            Assert.AreEqual(entity.Name, converted.Name);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.Lesson()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Description",
                Didactics = "Didactics",
                Name = "Name"
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.CoursePlanningId, converted.CoursePlanningId);
            Assert.AreEqual(dbEntity.Date, converted.Date);
            Assert.AreEqual(dbEntity.Description, converted.Description);
            Assert.AreEqual(dbEntity.Didactics, converted.Didactics);
            Assert.AreEqual(dbEntity.Name, converted.Name);
        }
    }
}
