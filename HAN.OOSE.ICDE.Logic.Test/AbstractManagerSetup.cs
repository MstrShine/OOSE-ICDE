using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Logic.Test
{
    [TestClass]
    public abstract class AbstractManagerSetup
    {
        protected List<AssessmentCriteria> _assessmentCriterias;
        protected List<AssessmentDimension> _assessmentDimensions;
        protected List<Competency> _competencies;
        protected List<Course> _courses;
        protected List<CoursePlanning> _coursePlannings;
        protected List<Exam> _exams;
        protected List<ExaminationEvent> _examinationEvents;
        protected List<GradeDescription> _gradeDescriptionms;
        protected List<LearningOutcome> _learningOutcomes;
        protected List<LearningOutcomeUnit> _learningOutcomeUnits;
        protected List<Lesson> _lessons;
        protected List<Study> _studies;
        protected List<User> _users;

        protected Mock<IAssessmentCriteriaRepositorySession> CreateAssessmentCriteriaRepositorySession()
        {
            var repositorySessionMock = new Mock<IAssessmentCriteriaRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<AssessmentCriteria>())).Returns<AssessmentCriteria>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _assessmentCriterias.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_assessmentCriterias)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _assessmentCriterias.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _assessmentCriterias.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<AssessmentCriteria>())).Returns<AssessmentCriteria>(x =>
            {
                var toUpdate = _assessmentCriterias.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _assessmentCriterias.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _assessmentCriterias.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByAssessmentDimensionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var criterias = _assessmentCriterias.Where(y => y.AssessmentDimensionId == x).ToList();
                return Task.FromResult(criterias);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeAssessmentDimensionIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _assessmentCriterias.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.AssessmentDimensionId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<IAssessmentDimensionRepositorySession> CreateAssessmentDimensionRepositorySession()
        {
            var repositorySessionMock = new Mock<IAssessmentDimensionRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<ICompetencyRepositorySession> CreateCompetencyRepositorySession()
        {
            var repositorySessionMock = new Mock<ICompetencyRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<ICourseRepositorySession> CreateCourseRepositorySession()
        {
            var repositorySessionMock = new Mock<ICourseRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<ICoursePlanningRepositorySession> CreateCoursePlanningRepositorySession()
        {
            var repositorySessionMock = new Mock<ICoursePlanningRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<IExamRepositorySession> CreateExamRepositorySession()
        {
            var repositorySessionMock = new Mock<IExamRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<IGradeDescriptionRepositorySession> CreateGradeDescriptionRepositorySession()
        {
            var repositorySessionMock = new Mock<IGradeDescriptionRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<ILearningOutcomeRepositorySession> CreateLearningOutcomeRepositorySession()
        {
            var repositorySessionMock = new Mock<ILearningOutcomeRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<ILearningOutcomeUnitRepositorySession> CreateLearningOutcomeUnitRepositorySession()
        {
            var repositorySessionMock = new Mock<ILearningOutcomeUnitRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<ILessonRepositorySession> CreateLessonRepositorySession()
        {
            var repositorySessionMock = new Mock<ILessonRepositorySession>();

            return repositorySessionMock;
        }

        protected Mock<IEntityRepositorySession<Study>> CreateStudyRepositorySession()
        {
            var repositorySessionMock = new Mock<IEntityRepositorySession<Study>>();

            return repositorySessionMock;
        }

        protected Mock<IEntityRepositorySession<User>> CreateUserRepositorySession()
        {
            var respositorySessionMock = new Mock<IEntityRepositorySession<User>>();

            return respositorySessionMock;
        }
    }
}