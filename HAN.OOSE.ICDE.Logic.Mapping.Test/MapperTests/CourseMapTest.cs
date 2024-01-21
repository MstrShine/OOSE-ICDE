namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class CourseMapTest : AbstractMapTest<Domain.Course, Persistency.Database.Domain.Course>
    {
        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                StudyId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
                CollegeYear = DateTime.Now.Year,
                CTE = 1,
                Description = "Description",
                IsFinalized = false
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.StudyId, converted.StudyId);
            Assert.AreEqual(entity.Name, converted.Name);
            Assert.AreEqual(entity.Code, converted.Code);
            Assert.AreEqual(entity.CollegeYear, converted.CollegeYear);
            Assert.AreEqual(entity.CTE, converted.CTE);
            Assert.AreEqual(entity.Description, converted.Description);
            Assert.AreEqual(entity.IsFinalized, converted.IsFinalized);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                StudyId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
                CollegeYear = DateTime.Now.Year,
                CTE = 1,
                Description = "Description",
                IsFinalized = false
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.StudyId, converted.StudyId);
            Assert.AreEqual(dbEntity.Name, converted.Name);
            Assert.AreEqual(dbEntity.Code, converted.Code);
            Assert.AreEqual(dbEntity.CollegeYear, converted.CollegeYear);
            Assert.AreEqual(dbEntity.CTE, converted.CTE);
            Assert.AreEqual(dbEntity.Description, converted.Description);
            Assert.AreEqual(dbEntity.IsFinalized, converted.IsFinalized);
        }

        protected override void SetupMapper()
        {
            _mapper = new CourseMap();
        }
    }
}
