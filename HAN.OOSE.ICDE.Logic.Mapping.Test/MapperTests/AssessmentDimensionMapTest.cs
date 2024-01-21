namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class AssessmentDimensionMapTest : AbstractMapTest<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension>
    {
        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.AssessmentDimension()
            {
                Id = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                ExamId = Guid.NewGuid(),
                Description = "Description"
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.Description, converted.Description);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.AssessmentDimension()
            {
                Id = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                ExamId = Guid.NewGuid(),
                Description = "Description"
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.Description, converted.Description);
        }

        protected override void SetupMapper()
        {
            _mapper = new AssessmentDimensionMap();
        }
    }
}
