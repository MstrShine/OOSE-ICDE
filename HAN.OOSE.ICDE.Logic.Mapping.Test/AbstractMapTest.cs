using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Logic.Mapping.Test
{
    [TestClass]
    public abstract class AbstractMapTest<T, Y> where T : Entity where Y : DBEntity
    {
        protected IEntityMapper<T, Y> _mapper;

        public AbstractMapTest()
        {
            SetupMapper();
        }

        protected abstract void SetupMapper();

        [TestMethod]
        public void EntityToDbEntity_Valid() => _EntityToDbEntity_Valid();

        protected abstract void _EntityToDbEntity_Valid();

        [TestMethod]
        public void DbEntityToEntity_Valid() => _DbEntityToEntity_Valid();

        protected abstract void _DbEntityToEntity_Valid();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EntityNull()
        {
            _mapper.FromEntity(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DbEntityNull()
        {
            _mapper.ToEntity(null);
        }

        protected void AssertEntity(T entity, Y converted)
        {
            Assert.AreEqual(entity.Id, converted.Id);
        }

        protected void AssertVersionedEntity(VersionedEntity entity, VersionDBEntity converted)
        {
            Assert.AreEqual(entity.Id, converted.Id);
            Assert.AreEqual(entity.Author, converted.Author);
            Assert.AreEqual(entity.VersionCollection, converted.VersionCollection);
            Assert.AreEqual(entity.DateOfCreation, converted.DateOfCreation);
        }

        protected void AssertDbEntity(Y dbEntity, T converted)
        {
            Assert.AreEqual(dbEntity.Id, converted.Id);
        }

        protected void AssertVersionedDbEntity(VersionDBEntity dbEntity, VersionedEntity converted)
        {
            Assert.AreEqual(dbEntity.Id, converted.Id);
            Assert.AreEqual(dbEntity.Author, converted.Author);
            Assert.AreEqual(dbEntity.VersionCollection, converted.VersionCollection);
            Assert.AreEqual(dbEntity.DateOfCreation, converted.DateOfCreation);
        }
    }
}