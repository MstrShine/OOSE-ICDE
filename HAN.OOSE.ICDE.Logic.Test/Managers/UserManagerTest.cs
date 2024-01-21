using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class UserManagerTest : EntityManagerTest<IUserManager, Domain.User>
    {
        public UserManagerTest()
        {
            var userSession = CreateUserRepositorySession();
            var userRepository = new Mock<IEntityRepository<IUserRepositorySession, Persistency.Database.Domain.User>>();
            userRepository.Setup(x => x.CreateSession()).Returns(userSession.Object);

            _manager = new UserManager(userRepository.Object, new UserMap());
        }
    }
}
