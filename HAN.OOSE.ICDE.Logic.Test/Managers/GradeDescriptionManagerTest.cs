using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Logic.Test.Managers.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class GradeDescriptionManagerTest : VersionedEntityManagerTest<IGradeDescriptionManager, Domain.GradeDescription>
    {
        public GradeDescriptionManagerTest()
        {
            var gradeDescriptionSessionMock = CreateGradeDescriptionRepositorySession();
            var gradeDescriptionRepositoryMock = new Mock<IEntityRepository<IGradeDescriptionRepositorySession, Persistency.Database.Domain.GradeDescription>>();
            gradeDescriptionRepositoryMock.Setup(x => x.CreateSession()).Returns(gradeDescriptionSessionMock.Object);

            _manager = new GradeDescriptionManager(gradeDescriptionRepositoryMock.Object, new GradeDescriptionMap());
        }
    }
}
