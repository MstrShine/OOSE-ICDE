using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;

namespace HAN.OOSE.ICDE.Logic.Test
{
    [TestClass]
    public abstract class VersionedEntityManagerTest<T, Y> : EntityManagerTest<T, Y> where T : IVersionedEntityManager<Y> where Y : VersionedEntity, new()
    {
        protected abstract Guid VersionIdForBasicTests { get; }

        protected abstract int VersionListCount { get; }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByVersionIdAsync_EmptyGuid()
        {
            await _manager.GetByVersionIdAsync(Guid.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateEntityAsync_EmptyVersionId()
        {
            await _manager.UpdateAsync(new Y() { Id = Guid.NewGuid(), VersionCollection = Guid.Empty });
        }

        [TestMethod]
        public async Task GetByVersionId_Valid()
        {
            var versions = await _manager.GetByVersionIdAsync(VersionIdForBasicTests);

            Assert.AreEqual(VersionListCount, versions.Count);
            Assert.IsTrue(versions.All(x => x.VersionCollection == VersionIdForBasicTests));
        }

        [TestMethod]
        public async Task GetByVersionId_IdNotFound()
        {
            var versions = await _manager.GetByVersionIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, versions.Count);
        }

        [TestMethod]
        public override async Task Save_Valid()
        {
            var newEntity = Construct();

            var beforeSaveCount = ListCount;
            var saved = await _manager.SaveAsync(newEntity);

            Assert.IsTrue(saved.Id != Guid.Empty);
            Assert.IsTrue(saved.Id != newEntity.Id);
            Assert.IsTrue(saved.VersionCollection != Guid.Empty);
            Assert.IsTrue(saved.VersionCollection != newEntity.VersionCollection);
            Assert.AreEqual(beforeSaveCount + 1, ListCount);
        }
    }
}
