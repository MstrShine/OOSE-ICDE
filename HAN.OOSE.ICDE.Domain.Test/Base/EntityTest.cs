using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain.Test.Base
{
    [TestClass]
    public class EntityTest<T> where T : Entity, new()
    {
        [TestMethod]
        public void Entity_NotValid_IdEmpty()
        {
            var entity = new T() { Id = Guid.Empty };

            Assert.IsFalse(entity.IsValid());
        }
    }
}