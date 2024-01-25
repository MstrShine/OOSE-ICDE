using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class ExamTest : VersionedEntityTest<Exam>
    {
        [TestMethod]
        public void Exam_NotValid_Name()
        {
            var entity = new Exam()
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
        public void Exam_NotValid_Code()
        {
            var entity = new Exam()
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
        public void Exam_NotValid_Weight()
        {
            var entity = new Exam()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                Weight = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Weight = -1;

            Assert.IsFalse(entity.IsValid());

            entity.Weight = 101;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Exam_NotValid_Type()
        {
            var entity = new Exam()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                Weight = 50,
                Type = null
            };

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Exam_NotValid_MinimumGrade()
        {
            var entity = new Exam()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                Weight = 50,
                Type = Enums.ExamType.Casus,
                MinimumGrade = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.MinimumGrade = -1;

            Assert.IsFalse(entity.IsValid());

            entity.MinimumGrade = 11;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Exam_NotValid_LearningOutcomeUnitId()
        {
            var entity = new Exam()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                Weight = 50,
                Type = Enums.ExamType.Casus,
                MinimumGrade = 5,
                LearningOutcomeUnitId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.LearningOutcomeUnitId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Exam_Valid()
        {
            var entity = new Exam()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                Weight = 50,
                Type = Enums.ExamType.Casus,
                MinimumGrade = 5,
                LearningOutcomeUnitId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
