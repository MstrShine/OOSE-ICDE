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
    public class ExaminationEventManagerTest : VersionedEntityManagerTest<IExaminationEventManager, Domain.ExaminationEvent>
    {
        protected override Guid VersionIdForBasicTests => _examinationEvent1Version;

        protected override int VersionListCount => _examinationEvents.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _examinationEvent1Id;

        protected override int ListCount => _examinationEvents.Count;

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
        public async Task GetByCoursePlanningId_Valid()
        {
            var examinationEvents = await _manager.GetByCoursePlanningIdAsync(_coursePlanning1Id);

            Assert.IsTrue(examinationEvents.All(x => x.CoursePlanningId == _coursePlanning1Id));
            Assert.AreEqual(_examinationEvents.Count(x => x.CoursePlanningId == _coursePlanning1Id), examinationEvents.Count);
        }

        [TestMethod]
        public async Task GetByCoursePlanningId_IdNotFound()
        {
            var examinationEvents = await _manager.GetByCoursePlanningIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, examinationEvents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByExamId_EmptyGuid()
        {
            await _manager.GetByCoursePlanningIdAsync(Guid.Empty);
        }

        [TestMethod]
        public async Task GetByExamId_Valid()
        {
            var examinationEvents = await _manager.GetByExamIdAsync(_exam1Id);

            Assert.IsTrue(examinationEvents.All(x => x.ExamId == _exam1Id));
            Assert.AreEqual(_examinationEvents.Count(x => x.ExamId == _exam1Id), examinationEvents.Count);
        }

        [TestMethod]
        public async Task GetByExamId_IdNotFound()
        {
            var examinationEvents = await _manager.GetByExamIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, examinationEvents.Count);
        }

        [TestMethod]
        public override async Task Update_Valid()
        {
            var toUpdate = await _manager.GetByIdAsync(IdForBasicTest);
            toUpdate.Prerequisites = "Test";

            var beforeUpdateCount = ListCount;
            await _manager.UpdateAsync(toUpdate);

            var updated = await _manager.GetByIdAsync(IdForBasicTest);

            Assert.AreEqual(IdForBasicTest, updated.Id);
            Assert.AreEqual("Test", updated.Prerequisites);
            Assert.AreEqual(beforeUpdateCount, ListCount);
        }

        protected override ExaminationEvent Construct()
        {
            return new()
            {
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CoursePlanningId = Guid.NewGuid(),
                ExamId = Guid.NewGuid(),
                Date = DateTime.Now,
                Prerequisites = "Prerequisites",
                Type = "Type",
            };
        }
    }
}
