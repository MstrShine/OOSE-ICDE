using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Logic.Test.Managers.Base;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class AssessmentCriteriaManagerTest : VersionedEntityManagerTest<IAssessmentCriteriaManager, Domain.AssessmentCriteria>
    {
        protected override Guid VersionIdForBasicTests => _assessmentCriteria1Version;

        protected override int VersionListCount => _assessmentCriterias.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _assessmentCriteria1Id;

        protected override int ListCount => _assessmentCriterias.Count;

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByAssessmentDimensionId_EmptyGuid()
        {
            await _manager.GetByAssessmentDimensionIdAsync(Guid.Empty);
        }

        [TestMethod]
        public async Task GetByAssessmentDimensionId_Valid()
        {
            var assessmentCriterias = await _manager.GetByAssessmentDimensionIdAsync(_assessmentDimension1Id);

            Assert.IsTrue(assessmentCriterias.All(x => x.AssessmentDimensionId == _assessmentDimension1Id));
            Assert.AreEqual(_assessmentCriterias.Count(x => x.AssessmentDimensionId == _assessmentDimension1Id), assessmentCriterias.Count);
        }

        [TestMethod]
        public async Task GetByAssessmentDimensionId_IdNotFound()
        {
            var assessmentCriteria = await _manager.GetByAssessmentDimensionIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, assessmentCriteria.Count);
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

        protected override Domain.AssessmentCriteria Construct()
        {
            return new()
            {
                DateOfCreation = DateTime.Now,
                Author = Guid.NewGuid(),
                AssessmentDimensionId = Guid.NewGuid(),
                Name = "Name",
                Explanation = "Explanation",
                Weight = 0,
                MinimumGrade = 0,
            };
        }
    }
}
