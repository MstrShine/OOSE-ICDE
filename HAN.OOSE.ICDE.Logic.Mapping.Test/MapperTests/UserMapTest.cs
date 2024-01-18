namespace HAN.OOSE.ICDE.Logic.Mapping.Test.MapperTests
{
    [TestClass]
    public class UserMapTest : AbstractMapTest<Domain.User, Persistency.Database.Domain.User>
    {
        protected override void SetupMapper()
        {
            _mapper = new UserMap();
        }

        protected override void _DbEntityToEntity_Valid()
        {
            var entity = new Domain.User()
            {
                Id = Guid.NewGuid(),
                Email = "Email",
                FirstName = "FirstName",
                LastName = "LastName",
                Password = "Password",
                Role = Domain.Enums.Role.Student
            };

            var converted = _mapper.FromEntity(entity);

            AssertEntity(entity, converted);
            Assert.AreEqual(entity.Email, converted.Email);
            Assert.AreEqual(entity.FirstName, converted.FirstName);
            Assert.AreEqual(entity.LastName, converted.LastName);
            Assert.AreEqual(entity.Password, converted.Password);
            Assert.AreEqual(entity.Role.ToString(), converted.Role.ToString());
        }

        protected override void _EntityToDbEntity_Valid()
        {
            var dbEntity = new Persistency.Database.Domain.User()
            {
                Id = Guid.NewGuid(),
                Email = "Email",
                FirstName = "FirstName",
                LastName = "LastName",
                Password = "Password",
                Role = Persistency.Database.Domain.Enums.Role.Student
            };

            var converted = _mapper.ToEntity(dbEntity);

            AssertDbEntity(dbEntity, converted);
            Assert.AreEqual(dbEntity.Email, converted.Email);
            Assert.AreEqual(dbEntity.FirstName, converted.FirstName);
            Assert.AreEqual(dbEntity.LastName, converted.LastName);
            Assert.AreEqual(dbEntity.Password, converted.Password);
            Assert.AreEqual(dbEntity.Role.ToString(), converted.Role.ToString());
        }
    }
}
