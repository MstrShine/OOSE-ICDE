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
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByLearningOutcomeUnitId_EmptyGuid()
        {
            await _manager.GetByLearningOutcomeUnitIdAsync(Guid.Empty);
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
