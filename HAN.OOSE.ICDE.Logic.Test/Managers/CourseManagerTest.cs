using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class CourseManagerTest : VersionedEntityManagerTest<ICourseManager, Domain.Course>
    {
        protected override Guid VersionIdForBasicTests => _course1Version;

        protected override int VersionListCount => _courses.Count(x => x.VersionCollection == VersionIdForBasicTests);

        protected override Guid IdForBasicTest => _course1Id;

        protected override int ListCount => _courses.Count;

        public CourseManagerTest()
        {
            var courseSession = CreateCourseRepositorySession();
            var courseRepository = new Mock<IEntityRepository<ICourseRepositorySession, Persistency.Database.Domain.Course>>();
            courseRepository.Setup(x => x.CreateSession()).Returns(courseSession.Object);

            var competencySession = CreateCompetencyRepositorySession();
            var competencyRepository = new Mock<IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency>>();
            competencyRepository.Setup(x => x.CreateSession()).Returns(competencySession.Object);

            var coursePlanningSession = CreateCoursePlanningRepositorySession();
            var coursePlanningRepository = new Mock<IEntityRepository<ICoursePlanningRepositorySession, Persistency.Database.Domain.CoursePlanning>>();
            coursePlanningRepository.Setup(x => x.CreateSession()).Returns(coursePlanningSession.Object);

            var learningOutcomeUnitSession = CreateLearningOutcomeUnitRepositorySession();
            var learningOutcomeUnitRepository = new Mock<IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit>>();
            learningOutcomeUnitRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeUnitSession.Object);

            _manager = new CourseManager(
                courseRepository.Object,
                new CourseMap(),
                competencyRepository.Object,
                coursePlanningRepository.Object,
                learningOutcomeUnitRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByStudyId_EmptyGuid()
        {
            await _manager.GetByStudyIdAsync(Guid.Empty);
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

        protected override Course Construct()
        {
            return new()
            {
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                StudyId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
                Description = "Description",
                CTE = 0,
                CollegeYear = 0,
                IsFinalized = false,
            };
        }
    }
}
