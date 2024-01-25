using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain.Test.Base
{
    [TestClass]
    public class VersionedEntityTest<T> : EntityTest<T> where T : VersionedEntity, new()
    {
        [TestMethod]
        public void VersionedEntity_NotValid_VersionCollectionEmpty()
        {
            var entity = new T() { Id = Guid.NewGuid(), VersionCollection = Guid.Empty };

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void VersionedEntity_NotValid_AuthorEmpty()
        {
            var entity = new T() { Id = Guid.NewGuid(), VersionCollection = Guid.NewGuid(), Author = Guid.Empty };

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void VersionedEntity_NotValid_DateOfCreationNull()
        {
            var entity = new T() { Id = Guid.NewGuid(), VersionCollection = Guid.NewGuid(), Author = Guid.NewGuid(), DateOfCreation = null };

            Assert.IsFalse(entity.IsValid());
        }
    }
}
