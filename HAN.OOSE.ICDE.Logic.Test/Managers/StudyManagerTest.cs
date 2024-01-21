using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class StudyManagerTest : EntityManagerTest<IEntityManager<Domain.Study>, Domain.Study>
    {
        public StudyManagerTest()
        {
            var studySession = CreateStudyRepositorySession();
            var studyRepository = new Mock<IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.Study>, Persistency.Database.Domain.Study>>();
            studyRepository.Setup(x => x.CreateSession()).Returns(studySession.Object);

            _manager = new StudyManager(new StudyMap(), studyRepository.Object);
        }
    }
}
