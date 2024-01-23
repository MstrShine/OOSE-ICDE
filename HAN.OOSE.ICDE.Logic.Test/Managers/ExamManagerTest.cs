using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Logic.Test.Managers.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class ExamManagerTest : VersionedEntityManagerTest<IExamManager, Domain.Exam>
    {
        public ExamManagerTest()
        {
            var examSession = CreateExamRepositorySession();
            var examRepository = new Mock<IEntityRepository<IExamRepositorySession, Persistency.Database.Domain.Exam>>();
            examRepository.Setup(x => x.CreateSession()).Returns(examSession.Object);

            var examinationEventSession = CreateExaminationEventRepositorySession();
            var examinationEventRepository = new Mock<IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent>>();
            examinationEventRepository.Setup(x => x.CreateSession()).Returns(examinationEventSession.Object);

            var assessmentDimensionSession = CreateAssessmentDimensionRepositorySession();
            var assessmentDimensionRepository = new Mock<IEntityRepository<IAssessmentDimensionRepositorySession, Persistency.Database.Domain.AssessmentDimension>>();
            assessmentDimensionRepository.Setup(x => x.CreateSession()).Returns(assessmentDimensionSession.Object);

            var learningOutcomeSession = CreateLearningOutcomeRepositorySession();
            var learningOutcomeRepository = new Mock<IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome>>();
            learningOutcomeRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeSession.Object);

            _manager = new ExamManager(
                examRepository.Object,
                new ExamMap(),
                examinationEventRepository.Object,
                assessmentDimensionRepository.Object,
                learningOutcomeRepository.Object);
        }
    }
}
