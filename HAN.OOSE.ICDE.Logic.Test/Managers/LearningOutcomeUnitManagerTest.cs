using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class LearningOutcomeUnitManagerTest : VersionedEntityManagerTest<ILearningOutcomeUnitManager, Domain.LearningOutcomeUnit>
    {
        public LearningOutcomeUnitManagerTest()
        {
            var learningOutcomeUnitSession = CreateLearningOutcomeUnitRepositorySession();
            var learningOutcomeUnitRepository = new Mock<IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit>>();
            learningOutcomeUnitRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeUnitSession.Object);

            var competencySession = CreateCompetencyRepositorySession();
            var competencyRepository = new Mock<IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency>>();
            competencyRepository.Setup(x => x.CreateSession()).Returns(competencySession.Object);

            var learningOutcomeSession = CreateLearningOutcomeRepositorySession();
            var learningOutcomeRepository = new Mock<IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome>>();
            learningOutcomeRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeSession.Object);

            var examSession = CreateExamRepositorySession();
            var examRepository = new Mock<IEntityRepository<IExamRepositorySession, Persistency.Database.Domain.Exam>>();
            examRepository.Setup(x => x.CreateSession()).Returns(examSession.Object);


            _manager = new LearningOutcomeUnitManager(
                learningOutcomeUnitRepository.Object,
                new LearningOutcomeUnitMap(),
                competencyRepository.Object,
                learningOutcomeRepository.Object,
                examRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByCourseId_EmptyGuid()
        {
            await _manager.GetByCourseIdAsync(Guid.Empty);
        }
    }
}
