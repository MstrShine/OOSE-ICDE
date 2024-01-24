using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class GradeDescriptionTest : VersionedEntityTest<GradeDescription>
    {
        [TestMethod]
        public void GradeDescription_NotValid_Grade()
        {
            var entity = new GradeDescription()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Grade = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Grade = -1;

            Assert.IsFalse(entity.IsValid());

            entity.Grade = 11;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void GradeDescription_NotValid_AssessmentCriteriaId()
        {
            var entity = new GradeDescription()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Grade = 5,
                AssessmentCriteriaId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.AssessmentCriteriaId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void GradeDescription_Valid()
        {
            var entity = new GradeDescription()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Grade = 5,
                AssessmentCriteriaId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
