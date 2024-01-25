using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class AssessmentCriteriaTest : VersionedEntityTest<AssessmentCriteria>
    {
        [TestMethod]
        public void AssessmentCriteria_NotValid_Name()
        {
            var entity = new AssessmentCriteria()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = null,
            };

            Assert.IsFalse(entity.IsValid());

            entity.Name = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void AssessmentCriteria_NotValid_Weight()
        {
            var entity = new AssessmentCriteria()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Weight = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Weight = -1;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void AssessmentCriteria_NotValid_MinimumGrade()
        {
            var entity = new AssessmentCriteria()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Weight = 5,
                MinimumGrade = null,
            };

            Assert.IsFalse(entity.IsValid());

            entity.MinimumGrade = -1;

            Assert.IsFalse(entity.IsValid());

            entity.MinimumGrade = 11;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void AssessmentCriteria_NotValid_AssessmentDimensionId()
        {
            var entity = new AssessmentCriteria()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Weight = 5,
                MinimumGrade = 5,
                AssessmentDimensionId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.AssessmentDimensionId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void AssessmentCriteria_Valid()
        {
            var entity = new AssessmentCriteria()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Weight = 5,
                MinimumGrade = 5,
                AssessmentDimensionId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
