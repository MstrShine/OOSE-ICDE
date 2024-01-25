using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class AssessmentDimensionTest : VersionedEntityTest<AssessmentDimension>
    {
        [TestMethod]
        public void AssessmentDimension_NotValid_Description()
        {
            var entity = new AssessmentDimension()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Description = null,
            };

            Assert.IsFalse(entity.IsValid());

            entity.Description = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void AssessmentDimension_NotValid_ExamId()
        {
            var entity = new AssessmentDimension()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Description = "Description",
                ExamId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.ExamId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void AssessmentDimension_Valid()
        {
            var entity = new AssessmentDimension()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Description = "Description",
                ExamId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
