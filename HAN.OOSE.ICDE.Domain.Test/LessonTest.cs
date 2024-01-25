using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class LessonTest : VersionedEntityTest<Lesson>
    {
        [TestMethod]
        public void Lesson_NotValid_Name()
        {
            var entity = new Lesson()
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
        public void Lesson_NotValid_Didactics()
        {
            var entity = new Lesson()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Didactics = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Didactics = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Lesson_NotValid_Date()
        {
            var entity = new Lesson()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Didactics = "Didactics",
                Date = null
            };

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Lesson_NotValid_CoursePlanningId()
        {
            var entity = new Lesson()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Didactics = "Didactics",
                Date = DateTime.Now,
                CoursePlanningId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CoursePlanningId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Lesson_NotValid_LearningOutcomeId()
        {
            var entity = new Lesson()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Didactics = "Didactics",
                Date = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                LearningOutcomeId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.LearningOutcomeId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Lesson_Valid()
        {
            var entity = new Lesson()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Didactics = "Didactics",
                Date = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                LearningOutcomeId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
