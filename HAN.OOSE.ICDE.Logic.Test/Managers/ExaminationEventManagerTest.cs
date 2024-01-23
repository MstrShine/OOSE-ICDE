using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class ExaminationEventManagerTest : VersionedEntityManagerTest<IExaminationEventManager, Domain.ExaminationEvent>
    {
        public ExaminationEventManagerTest()
        {
            var examinationEventSession = CreateExaminationEventRepositorySession();
            var examinationEventRepository = new Mock<IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent>>();
            examinationEventRepository.Setup(x => x.CreateSession()).Returns(examinationEventSession.Object);


            _manager = new ExaminationEventManager(examinationEventRepository.Object, new ExaminationEventMap());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByCoursePlanningId_EmptyGuid()
        {
            await _manager.GetByCoursePlanningIdAsync(Guid.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByExamId_EmptyGuid()
        {
            await _manager.GetByCoursePlanningIdAsync(Guid.Empty);
        }
    }
}
