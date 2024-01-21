namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class GradeDescriptionMapTest : AbstractMapTest<Domain.GradeDescription, Persistency.Database.Domain.GradeDescription>
    {
        protected override void SetupMapper()
        {
            _mapper = new GradeDescriptionMap();
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.GradeDescription()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                AssessmentCriteriaId = Guid.NewGuid(),
                Description = "Description",
                Grade = 5,
            };

            var converted = _mapper.FromEntity(entity);

            AssertVersionedEntity(entity, converted);
            Assert.AreEqual(entity.AssessmentCriteriaId, converted.AssessmentCriteriaId);
            Assert.AreEqual(entity.Description, converted.Description);
            Assert.AreEqual(entity.Grade, converted.Grade);
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.GradeDescription()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                AssessmentCriteriaId = Guid.NewGuid(),
                Description = "Description",
                Grade = 5,
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertVersionedDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.AssessmentCriteriaId, converted.AssessmentCriteriaId);
            Assert.AreEqual(dbEntity.Description, converted.Description);
            Assert.AreEqual(dbEntity.Grade, converted.Grade);
        }
    }
}
