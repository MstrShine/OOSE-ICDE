using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class CompetencyManagerTest : VersionedEntityManagerTest<ICompetencyManager, Domain.Competency>
    {
        protected override Guid VersionIdForBasicTests => _competency1Version;

        protected override int VersionListCount => _competencies.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _competency1Id;

        protected override int ListCount => _competencies.Count;

        public CompetencyManagerTest()
        {
            var competencySession = CreateCompetencyRepositorySession();
            var competencyRepository = new Mock<IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency>>();
            competencyRepository.Setup(x => x.CreateSession()).Returns(competencySession.Object);

            _manager = new CompetencyManager(competencyRepository.Object, new CompetencyMap());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByCourseId_EmptyGuid()
        {
            await _manager.GetByCourseIdAsync(Guid.Empty);
        }

        [TestMethod]
        public async Task GetByCourseId_Valid()
        {
            var competencies = await _manager.GetByCourseIdAsync(_course1Id);

            Assert.IsTrue(competencies.All(x => x.CourseId == _course1Id));
            Assert.AreEqual(_competencies.Count(x => x.CourseId == _course1Id), competencies.Count);
        }

        [TestMethod]
        public async Task GetByCourseId_IdNotFound()
        {
            var competencies = await _manager.GetByCourseIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, competencies.Count);
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
            var competencies = await _manager.GetByLearningOutcomeUnitIdAsync(_learningOutcomeUnit1Id);

            Assert.IsTrue(competencies.All(x => x.LearningOutcomeUnitId == _learningOutcomeUnit1Id));
            Assert.AreEqual(_competencies.Count(x => x.LearningOutcomeUnitId == _learningOutcomeUnit1Id), competencies.Count);
        }

        [TestMethod]
        public async Task GetByLearningOutcomeUnitId_IdNotFound()
        {
            var competencies = await _manager.GetByLearningOutcomeUnitIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, competencies.Count);
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

        protected override Competency Construct()
        {
            return new()
            {
                DateOfCreation = DateTime.Now,
                Author = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                LearningOutcomeUnitId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
            };
        }
    }
}
