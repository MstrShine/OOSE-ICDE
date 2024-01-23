using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class ExamManagerTest : VersionedEntityManagerTest<IExamManager, Domain.Exam>
    {
        protected override Guid VersionIdForBasicTests => _exam1Version;

        protected override int VersionListCount => _exams.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _exam1Id;

        protected override int ListCount => _exams.Count;

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByLearningOutcomeUnitId_EmptyGuid()
        {
            await _manager.GetByLearningOutcomeUnitIdAsync(Guid.Empty);
        }

        [TestMethod]
        public async Task GetByLearningOutcomeUnitId_Valid()
        {
            var exams = await _manager.GetByLearningOutcomeUnitIdAsync(_learningOutcomeUnit1Id);

            Assert.IsTrue(exams.All(x => x.LearningOutcomeUnitId == _learningOutcomeUnit1Id));
            Assert.AreEqual(_exams.Count(x => x.LearningOutcomeUnitId == _learningOutcomeUnit1Id), exams.Count);
        }

        [TestMethod]
        public async Task GetByLearningOutcomeUnitId_IdNotFound()
        {
            var exams = await _manager.GetByLearningOutcomeUnitIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, exams.Count);
        }

        [TestMethod]
        public override async Task Update_Valid()
        {
            var toUpdate = await _manager.GetByIdAsync(IdForBasicTest);
            toUpdate.Name = "Test";

            var beforeUpdateCount = ListCount;
            await _manager.UpdateAsync(toUpdate);

            var updated = await _manager.GetByIdAsync(IdForBasicTest);

            Assert.AreEqual(IdForBasicTest, updated.Id);
            Assert.AreEqual("Test", updated.Name);
            Assert.AreEqual(beforeUpdateCount, ListCount);
        }

        protected override Exam Construct()
        {
            return new()
            {
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                LearningOutcomeUnitId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
                MinimumGrade = 0,
                Type = Domain.Enums.ExamType.Casus,
                Weight = 0
            };
        }
    }
}
