using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class CoursePlanningManagerTest : VersionedEntityManagerTest<ICoursePlanningManager, Domain.CoursePlanning>
    {
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
    }
}
