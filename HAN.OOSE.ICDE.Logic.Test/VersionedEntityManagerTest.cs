using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;

namespace HAN.OOSE.ICDE.Logic.Test
{
    [TestClass]
    public class VersionedEntityManagerTest<T, Y> : EntityManagerTest<T, Y> where T : IVersionedEntityManager<Y> where Y : VersionedEntity, new()
    {
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
    }
}
