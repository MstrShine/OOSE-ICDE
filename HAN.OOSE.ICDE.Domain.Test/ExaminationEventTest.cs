using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class ExaminationEventTest : VersionedEntityTest<ExaminationEvent>
    {
        [TestMethod]
        public void ExaminationEvent_NotValid_Type()
        {
            var entity = new ExaminationEvent()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Type = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Type = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void ExaminationEvent_NotValid_Date()
        {
            var entity = new ExaminationEvent()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Type = "Type",
                Date = null
            };

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void ExaminationEvent_NotValid_CoursePlanningId()
        {
            var entity = new ExaminationEvent()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Type = "Type",
                Date = DateTime.Now,
                CoursePlanningId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CoursePlanningId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void ExaminationEvent_NotValid_ExamId()
        {
            var entity = new ExaminationEvent()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Type = "Type",
                Date = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                ExamId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.ExamId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void ExaminationEvent_Valid()
        {
            var entity = new ExaminationEvent()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Type = "Type",
                Date = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                ExamId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
