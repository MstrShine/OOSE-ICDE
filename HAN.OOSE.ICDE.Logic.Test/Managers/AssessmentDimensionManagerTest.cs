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
    public class AssessmentDimensionManagerTest : VersionedEntityManagerTest<IAssessmentDimensionManager, AssessmentDimension>
    {
        protected override Guid VersionIdForBasicTests => _assessmentDimension1Version;

        protected override int VersionListCount => _assessmentDimensions.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _assessmentDimension1Id;

        protected override int ListCount => _assessmentDimensions.Count;

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

        [TestMethod]
        public async Task GetByExamId_Valid()
        {
            var assessmentDimensions = await _manager.GetByExamIdAsync(_exam1Id);

            Assert.IsTrue(assessmentDimensions.All(x => x.ExamId == _exam1Id));
            Assert.AreEqual(_assessmentDimensions.Count(x => x.ExamId == _exam1Id), assessmentDimensions.Count);
        }

        [TestMethod]
        public async Task GetByExamId_IdNotFound()
        {
            var assessmentDimensions = await _manager.GetByExamIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, assessmentDimensions.Count);
        }

        [TestMethod]
        public override async Task Update_Valid()
        {
            var toUpdate = await _manager.GetByIdAsync(IdForBasicTest);
            toUpdate.Description = "Test";

            var beforeUpdateCount = ListCount;
            await _manager.UpdateAsync(toUpdate);

            var updated = await _manager.GetByIdAsync(IdForBasicTest);

            Assert.AreEqual(IdForBasicTest, updated.Id);
            Assert.AreEqual("Test", updated.Description);
            Assert.AreEqual(beforeUpdateCount, ListCount);
        }

        protected override AssessmentDimension Construct()
        {
            return new()
            {
                DateOfCreation = DateTime.Now,
                Author = Guid.NewGuid(),
                ExamId = Guid.NewGuid(),
                Description = "Description"
            };
        }
    }
}
