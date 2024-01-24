using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class LearningOutcomeUnitTest : VersionedEntityTest<LearningOutcomeUnit>
    {
        [TestMethod]
        public void LearningOutcomeUnit_NotValid_Name()
        {
            var entity = new LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Name = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcomeUnit_NotValid_Code()
        {
            var entity = new LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Code = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcomeUnit_NotValid_CTE()
        {
            var entity = new LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CTE = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CTE = -1;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcomeUnit_NotValid_MinimumGrade()
        {
            var entity = new LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CTE = 30,
                MinimumGrade = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.MinimumGrade = -1;

            Assert.IsFalse(entity.IsValid());

            entity.MinimumGrade = 11;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcomeUnit_NotValid_CourseId()
        {
            var entity = new LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CTE = 30,
                MinimumGrade = 5,
                CourseId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CourseId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcomeUnit_Valid()
        {
            var entity = new LearningOutcomeUnit()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CTE = 30,
                MinimumGrade = 5,
                CourseId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
