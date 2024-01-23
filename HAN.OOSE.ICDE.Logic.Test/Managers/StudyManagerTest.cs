using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class StudyManagerTest : EntityManagerTest<IEntityManager<Domain.Study>, Domain.Study>
    {
        protected override Guid IdForBasicTest => _study1Id;

        protected override int ListCount => _studies.Count;

        public StudyManagerTest()
        {
            var studySession = CreateStudyRepositorySession();
            var studyRepository = new Mock<IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.Study>, Persistency.Database.Domain.Study>>();
            studyRepository.Setup(x => x.CreateSession()).Returns(studySession.Object);

            _manager = new StudyManager(new StudyMap(), studyRepository.Object);
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

        protected override Study Construct()
        {
            return new()
            {
                Name = "Name",
                IsDeleted = false
            };
        }
    }
}
