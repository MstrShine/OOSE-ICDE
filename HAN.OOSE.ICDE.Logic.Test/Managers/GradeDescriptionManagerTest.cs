using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class GradeDescriptionManagerTest : VersionedEntityManagerTest<IGradeDescriptionManager, Domain.GradeDescription>
    {
        protected override Guid VersionIdForBasicTests => _gradeDescription1Version;

        protected override int VersionListCount => _gradeDescriptions.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _gradeDescription1Id;

        protected override int ListCount => _gradeDescriptions.Count;

        public GradeDescriptionManagerTest()
        {
            var gradeDescriptionSessionMock = CreateGradeDescriptionRepositorySession();
            var gradeDescriptionRepositoryMock = new Mock<IEntityRepository<IGradeDescriptionRepositorySession, Persistency.Database.Domain.GradeDescription>>();
            gradeDescriptionRepositoryMock.Setup(x => x.CreateSession()).Returns(gradeDescriptionSessionMock.Object);

            _manager = new GradeDescriptionManager(gradeDescriptionRepositoryMock.Object, new GradeDescriptionMap());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByAssessmentCriteriaId_EmptyGuid()
        {
            await _manager.GetByAssessmentCriteriaIdAsync(Guid.Empty);
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

        protected override GradeDescription Construct()
        {
            return new()
            {
                Author = Guid.Empty,
                DateOfCreation = DateTime.Now,
                AssessmentCriteriaId = Guid.Empty,
                Description = "Description",
                Grade = 0
            };
        }
    }
}
