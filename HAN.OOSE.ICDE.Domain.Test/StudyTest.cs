using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class StudyTest : EntityTest<Study>
    {
        [TestMethod]
        public void Study_NotValid_Name()
        {
            var entity = new Study()
            {
                Id = Guid.NewGuid(),
                Name = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Name = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Study_Valid()
        {
            var entity = new Study()
            {
                Id = Guid.NewGuid(),
                Name = "Name"
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
