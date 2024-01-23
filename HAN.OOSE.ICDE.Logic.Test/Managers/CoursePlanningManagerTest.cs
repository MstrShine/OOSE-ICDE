using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class CoursePlanningManagerTest : VersionedEntityManagerTest<ICoursePlanningManager, Domain.CoursePlanning>
    {
        protected override Guid VersionIdForBasicTests => _coursePlanning1Version;

        protected override int VersionListCount => _coursePlannings.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _coursePlanning1Id;

        protected override int ListCount => _coursePlannings.Count;

        public CoursePlanningManagerTest()
        {
            var coursePlanningSession = CreateCoursePlanningRepositorySession();
            var coursePlanningRepository = new Mock<IEntityRepository<ICoursePlanningRepositorySession, Persistency.Database.Domain.CoursePlanning>>();
            coursePlanningRepository.Setup(x => x.CreateSession()).Returns(coursePlanningSession.Object);

            var examinationEventSession = CreateExaminationEventRepositorySession();
            var examinationEventRepository = new Mock<IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent>>();
            examinationEventRepository.Setup(x => x.CreateSession()).Returns(examinationEventSession.Object);

            var lessonSession = CreateLessonRepositorySession();
            var lessonRepository = new Mock<IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson>>();
            lessonRepository.Setup(x => x.CreateSession()).Returns(lessonSession.Object);


            _manager = new CoursePlanningManager(
                coursePlanningRepository.Object,
                new CoursePlanningMap(),
                examinationEventRepository.Object,
                lessonRepository.Object);
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
            var coursePlanning = await _manager.GetByCourseIdAsync(_course1Id);

            Assert.IsNotNull(coursePlanning);
            Assert.AreEqual(_course1Id, coursePlanning.CourseId);
        }

        [TestMethod]
        public async Task GetByCourseId_IdNotFound()
        {
            var coursePlanning = await _manager.GetByCourseIdAsync(Guid.NewGuid());

            Assert.IsNull(coursePlanning);
        }

        [TestMethod]
        public override async Task Update_Valid()
        {
            var toUpdate = await _manager.GetByIdAsync(IdForBasicTest);
            toUpdate.CourseId = Guid.Empty;

            var beforeUpdateCount = ListCount;
            await _manager.UpdateAsync(toUpdate);

            var updated = await _manager.GetByIdAsync(IdForBasicTest);

            Assert.AreEqual(IdForBasicTest, updated.Id);
            Assert.AreEqual(Guid.Empty, updated.CourseId);
            Assert.AreEqual(beforeUpdateCount, ListCount);
        }

        protected override CoursePlanning Construct()
        {
            return new()
            {
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
            };
        }
    }
}
