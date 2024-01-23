using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class AssessmentDimensionManagerTest : VersionedEntityManagerTest<IAssessmentDimensionManager, AssessmentDimension>
    {
        public AssessmentDimensionManagerTest()
        {
            var assessmentDimensionSession = CreateAssessmentDimensionRepositorySession();
            var assessmentDimensionRepository = new Mock<IEntityRepository<IAssessmentDimensionRepositorySession, Persistency.Database.Domain.AssessmentDimension>>();
            assessmentDimensionRepository.Setup(x => x.CreateSession()).Returns(assessmentDimensionSession.Object);

            var assessmentCriteriaSession = CreateAssessmentCriteriaRepositorySession();
            var assessmentCriteriaRepositoryMock = new Mock<IEntityRepository<IAssessmentCriteriaRepositorySession, Persistency.Database.Domain.AssessmentCriteria>>();
            assessmentCriteriaRepositoryMock.Setup(x => x.CreateSession()).Returns(assessmentCriteriaSession.Object);

            _manager = new AssessmentDimensionManager(assessmentDimensionRepository.Object, new AssessmentDimensionMap(), assessmentCriteriaRepositoryMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByExamId_EmptyGuid()
        {
            await _manager.GetByExamIdAsync(Guid.Empty);
        }
    }
}
