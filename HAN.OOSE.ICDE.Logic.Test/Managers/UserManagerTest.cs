using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Logic.Test.Managers.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class UserManagerTest : EntityManagerTest<IUserManager, Domain.User>
    {
        protected override Guid IdForBasicTest => _user1Id;

        protected override int ListCount => _users.Count;

        public UserManagerTest()
        {
            var userSession = CreateUserRepositorySession();
            var userRepository = new Mock<IEntityRepository<IUserRepositorySession, Persistency.Database.Domain.User>>();
            userRepository.Setup(x => x.CreateSession()).Returns(userSession.Object);

            _manager = new UserManager(userRepository.Object, new UserMap());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByEmail_EmptyString()
        {
            await _manager.GetByEmailAsync("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByEmail_Null()
        {
            await _manager.GetByEmailAsync(null);
        }

        [TestMethod]
        public async Task GetByEmail_Valid()
        {
            var user = await _manager.GetByEmailAsync(_userEmail);

            Assert.AreEqual(_userEmail, user.Email);
        }

        [TestMethod]
        public async Task GetByEmail_EmailNotFound()
        {
            var user = await _manager.GetByEmailAsync("email@email.com");

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public override async Task Update_Valid()
        {
            var toUpdate = await _manager.GetByIdAsync(IdForBasicTest);
            toUpdate.FirstName = "Test";

            var beforeUpdateCount = ListCount;
            await _manager.UpdateAsync(toUpdate);

            var updated = await _manager.GetByIdAsync(IdForBasicTest);

            Assert.AreEqual(IdForBasicTest, updated.Id);
            Assert.AreEqual("Test", updated.FirstName);
            Assert.AreEqual(beforeUpdateCount, ListCount);
        }

        protected override User Construct()
        {
            return new()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "Email",
                Password = "Password",
                Role = Domain.Enums.Role.Student,
                IsDeleted = false,
            };
        }
    }
}
