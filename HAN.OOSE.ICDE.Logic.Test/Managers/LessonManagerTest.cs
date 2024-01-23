using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class LessonManagerTest : VersionedEntityManagerTest<ILessonManager, Domain.Lesson>
    {
        protected override Guid VersionIdForBasicTests => _lesson1Version;

        protected override int VersionListCount => _lessons.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _lesson1Id;

        protected override int ListCount => _lessons.Count;

        public LessonManagerTest()
        {
            var lessonSession = CreateLessonRepositorySession();
            var lessonRepository = new Mock<IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson>>();
            lessonRepository.Setup(x => x.CreateSession()).Returns(lessonSession.Object);

            var learningOutcomeSession = CreateLearningOutcomeRepositorySession();
            var learningOutcomeRepository = new Mock<IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome>>();
            learningOutcomeRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeSession.Object);


            _manager = new LessonManager(lessonRepository.Object, new LessonMap(), learningOutcomeRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByCoursePlanningId_EmptyGuid()
        {
            await _manager.GetByCoursePlanningIdAsync(Guid.Empty);
        }

        [TestMethod]
        public async Task GetByCoursePlanningId_Valid()
        {
            var lessons = await _manager.GetByCoursePlanningIdAsync(_coursePlanning1Id);

            Assert.IsTrue(lessons.All(x => x.CoursePlanningId == _coursePlanning1Id));
            Assert.AreEqual(_lessons.Count(x => x.CoursePlanningId == _coursePlanning1Id), lessons.Count);
        }

        [TestMethod]
        public async Task GetByCoursePlanningId_IdNotFound()
        {
            var lessons = await _manager.GetByCoursePlanningIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, lessons.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByLearningOutcomeId_EmptyGuid()
        {
            await _manager.GetByLearningOutcomeIdAsync(Guid.Empty);
        }

        [TestMethod]
        public async Task GetByLearningOutcomeId_Valid()
        {
            var lessons = await _manager.GetByLearningOutcomeIdAsync(_learningOutcome1Id);

            Assert.IsTrue(lessons.All(x => x.LearningOutcomeId == _learningOutcome1Id));
            Assert.AreEqual(_lessons.Count(x => x.LearningOutcomeId == _learningOutcome1Id), lessons.Count);
        }

        [TestMethod]
        public async Task GetByLearningOutcomeId_IdNotFound()
        {
            var lessons = await _manager.GetByLearningOutcomeIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, lessons.Count);
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

        protected override Lesson Construct()
        {
            return new()
            {
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                LearningOutcomeId = Guid.NewGuid(),
                Name = "Name",
                Description = "Description",
                Didactics = "Didactics",
                Date = DateTime.Now,
            };
        }
    }
}
