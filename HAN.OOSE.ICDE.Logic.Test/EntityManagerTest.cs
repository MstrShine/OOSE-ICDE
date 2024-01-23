using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;

namespace HAN.OOSE.ICDE.Logic.Test
{
    [TestClass]
    public abstract class EntityManagerTest<T, Y> : AbstractManagerSetup where T : IEntityManager<Y> where Y : Entity, new()
    {
        protected T _manager;

        protected abstract Guid IdForBasicTest { get; }

        protected abstract int ListCount { get; }

        protected abstract Y Construct();

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

        [TestMethod]
        public async Task GetById_Valid()
        {
            var entity = await _manager.GetByIdAsync(IdForBasicTest);

            Assert.AreEqual(IdForBasicTest, entity.Id);
        }

        [TestMethod]
        public async Task GetById_IdNotFound()
        {
            var entity = await _manager.GetByIdAsync(Guid.NewGuid());

            Assert.IsTrue(entity == null);
        }

        [TestMethod]
        public async Task GetAll_Valid()
        {
            var entities = await _manager.GetAllAsync();

            Assert.AreEqual(ListCount, entities.Count);
        }

        [TestMethod]
        public virtual async Task Save_Valid()
        {
            var newEntity = Construct();

            var beforeSaveCount = ListCount;
            var saved = await _manager.SaveAsync(newEntity);

            Assert.IsTrue(saved.Id != Guid.Empty);
            Assert.IsTrue(saved.Id != newEntity.Id);
            Assert.AreEqual(beforeSaveCount + 1, ListCount);
        }

        [TestMethod]
        public abstract Task Update_Valid();

        [TestMethod]
        public async Task Delete_Valid()
        {
            var beforeDeleteCount = ListCount;

            await _manager.DeleteAsync(IdForBasicTest);

            Assert.AreEqual(beforeDeleteCount - 1, ListCount);
        }
    }
}
