using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class LearningOutcomeTest : VersionedEntityTest<LearningOutcome>
    {
        [TestMethod]
        public void LearningOutcome_NotValid_Name()
        {
            var entity = new LearningOutcome()
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
        public void LearningOutcome_NotValid_Description()
        {
            var entity = new LearningOutcome()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Description = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Description = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcome_NotValid_ExamId()
        {
            var entity = new LearningOutcome()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Description = "Description",
                ExamId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.ExamId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcome_NotValid_LearningOutcomeUnitId()
        {
            var entity = new LearningOutcome()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Description = "Description",
                ExamId = Guid.NewGuid(),
                LearningOutcomeUnitId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.LearningOutcomeUnitId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void LearningOutcome_Valid()
        {
            var entity = new LearningOutcome()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Description = "Description",
                ExamId = Guid.NewGuid(),
                LearningOutcomeUnitId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
