using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class UserTest : EntityTest<User>
    {
        [TestMethod]
        public void User_NotValid_Email()
        {
            var entity = new User()
            {
                Id = Guid.NewGuid(),
                Email = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Email = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void User_NotValid_Password()
        {
            var entity = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Email",
                Password = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Password = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void User_NotValid_FirstName()
        {
            var entity = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Email",
                Password = "Password",
                FirstName = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.FirstName = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void User_NotValid_LastName()
        {
            var entity = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Email",
                Password = "Password",
                FirstName = "FirstName",
                LastName = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.LastName = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void User_Valid()
        {
            var entity = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Email",
                Password = "Password",
                FirstName = "FirstName",
                LastName = "LastName"
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
