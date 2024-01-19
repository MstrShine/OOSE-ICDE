namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class StudyMapTest : AbstractMapTest<Domain.Study, Persistency.Database.Domain.Study>
    {
        protected override void SetupMapper()
        {
            _mapper = new StudyMap();
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.Study()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
            };

            var converted = _mapper.FromEntity(entity);

            AssertEntity(entity, converted);
            Assert.AreEqual(entity.Name, converted.Name);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.Study()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.Name, converted.Name);
        }
    }
}
