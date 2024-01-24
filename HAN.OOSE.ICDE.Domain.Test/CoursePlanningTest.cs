using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class CoursePlanningTest : VersionedEntityTest<CoursePlanning>
    {
        [TestMethod]
        public void CoursePlanning_NotValid_CourseId()
        {
            var entity = new CoursePlanning()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CourseId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void CoursePlanning_Valid()
        {
            var entity = new CoursePlanning()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
