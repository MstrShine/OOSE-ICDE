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
    public class LearningOutcomeManagerTest : VersionedEntityManagerTest<ILearningOutcomeManager, Domain.LearningOutcome>
    {
        protected override Guid VersionIdForBasicTests => _learningOutcome1Version;

        protected override int VersionListCount => _learningOutcomes.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _learningOutcome1Id;

        protected override int ListCount => _learningOutcomes.Count;

        public LearningOutcomeManagerTest()
        {
            var learningOutcomeSession = CreateLearningOutcomeRepositorySession();
            var learningOutcomeRepository = new Mock<IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome>>();
            learningOutcomeRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeSession.Object);

            var lessonSession = CreateLessonRepositorySession();
            var lessonRepository = new Mock<IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson>>();
            lessonRepository.Setup(x => x.CreateSession()).Returns(lessonSession.Object);

            _manager = new LearningOutcomeManager(learningOutcomeRepository.Object, new LearningOutcomeMap(), lessonRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByExamId_EmptyGuid()
        {
            await _manager.GetByExamIdAsync(Guid.Empty);
        }

        [TestMethod]
        public async Task GetByExamId_Valid()
        {
            var learningOutcomes = await _manager.GetByExamIdAsync(_exam1Id);

            Assert.IsTrue(learningOutcomes.All(x => x.ExamId == _exam1Id));
            Assert.AreEqual(_learningOutcomes.Count(x => x.ExamId == _exam1Id), learningOutcomes.Count);
        }

        [TestMethod]
        public async Task GetByExamId_IdNotFound()
        {
            var learningOutcomes = await _manager.GetByExamIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, learningOutcomes.Count);
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
            var learningOutcomes = await _manager.GetByLearningOutcomeUnitIdAsync(_learningOutcomeUnit1Id);

            Assert.IsTrue(learningOutcomes.All(x => x.LearningOutcomeUnitId == _learningOutcomeUnit1Id));
            Assert.AreEqual(_learningOutcomes.Count(x => x.LearningOutcomeUnitId == _learningOutcomeUnit1Id), learningOutcomes.Count);

        }

        [TestMethod]
        public async Task GetByLearningOutcomeUnitId_IdNotFound()
        {
            var learningOutcomes = await _manager.GetByLearningOutcomeUnitIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, learningOutcomes.Count);
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

        protected override LearningOutcome Construct()
        {
            return new()
            {
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                ExamId = Guid.NewGuid(),
                LearningOutcomeUnitId = Guid.NewGuid(),
                Name = "Name",
                Description = "Description",
            };
        }
    }
}
