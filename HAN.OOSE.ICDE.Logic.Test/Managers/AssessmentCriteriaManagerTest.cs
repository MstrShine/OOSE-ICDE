using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class AssessmentCriteriaManagerTest : VersionedEntityManagerTest<IAssessmentCriteriaManager, Domain.AssessmentCriteria>
    {
        public AssessmentCriteriaManagerTest()
        {
            var repositorySessionMock = CreateAssessmentCriteriaRepositorySession();
            var gradeDescriptionSessionMock = CreateGradeDescriptionRepositorySession();

            var assessmentCriteriaRepositoryMock = new Mock<IEntityRepository<IAssessmentCriteriaRepositorySession, AssessmentCriteria>>();
            assessmentCriteriaRepositoryMock.Setup(x => x.CreateSession()).Returns(repositorySessionMock.Object);

            var gradeDescriptionRepositoryMock = new Mock<IEntityRepository<IGradeDescriptionRepositorySession, GradeDescription>>();
            gradeDescriptionRepositoryMock.Setup(x => x.CreateSession()).Returns(gradeDescriptionSessionMock.Object);

            _manager = new AssessmentCriteriaManager(assessmentCriteriaRepositoryMock.Object, new AssessmentCriteriaMap(), gradeDescriptionRepositoryMock.Object);
        }
    }
}
