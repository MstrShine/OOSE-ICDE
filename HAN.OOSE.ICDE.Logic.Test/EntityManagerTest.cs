using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;

namespace HAN.OOSE.ICDE.Logic.Test
{
    [TestClass]
    public abstract class EntityManagerTest<T, Y> : AbstractManagerSetup where T : IEntityManager<Y> where Y : Entity, new()
    {
        protected T _manager;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DeleteAsync_EmptyGuid()
        {
            await _manager.DeleteAsync(Guid.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByIdAsync_EmptyGuid()
        {
            await _manager.GetByIdAsync(Guid.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task SaveEntityAsync_EmptyEntity()
        {
            await _manager.SaveAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateEntityAsync_EmptyEntity()
        {
            await _manager.UpdateAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateEntityAsync_EmptyGuid()
        {
            await _manager.UpdateAsync(new Y() { Id = Guid.Empty });
        }
    }
}
