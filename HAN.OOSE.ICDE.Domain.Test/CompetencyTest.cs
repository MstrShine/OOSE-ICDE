using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class CompetencyTest : VersionedEntityTest<Competency>
    {
        [TestMethod]
        public void Competency_NotValid_Code()
        {
            var entity = new Competency()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Code = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Code = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Competency_NotValid_Name()
        {
            var entity = new Competency()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Code = "Code",
                Name = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Name = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Competency_NotValid_CourseId()
        {
            var entity = new Competency()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Code = "Code",
                Name = "Name",
                CourseId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CourseId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Competency_NotValid_LearningOutcomeUnitId()
        {
            var entity = new Competency()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Code = "Code",
                Name = "Name",
                CourseId = Guid.NewGuid(),
                LearningOutcomeUnitId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.LearningOutcomeUnitId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Competency_Valid()
        {
            var entity = new Competency()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Code = "Code",
                Name = "Name",
                CourseId = Guid.NewGuid(),
                LearningOutcomeUnitId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
