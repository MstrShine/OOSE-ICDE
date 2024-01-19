namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class CoursePlanningMapTest : AbstractMapTest<Domain.CoursePlanning, Persistency.Database.Domain.CoursePlanning>
    {
        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.CoursePlanning()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedDbEntity(converted, entity);
            Assert.AreEqual(entity.CourseId, converted.CourseId);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.CoursePlanning()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.CourseId, converted.CourseId);
        }

        protected override void SetupMapper()
        {
            _mapper = new CoursePlanningMap();
        }
    }
}
