using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Logic.Test
{
    [TestClass]
    public abstract class AbstractManagerSetup
    {
        protected List<AssessmentCriteria> _assessmentCriterias = new();
        protected List<AssessmentDimension> _assessmentDimensions = new();
        protected List<Competency> _competencies = new();
        protected List<Course> _courses = new();
        protected List<CoursePlanning> _coursePlannings = new();
        protected List<Exam> _exams = new();
        protected List<ExaminationEvent> _examinationEvents = new();
        protected List<GradeDescription> _gradeDescriptions = new();
        protected List<LearningOutcome> _learningOutcomes = new();
        protected List<LearningOutcomeUnit> _learningOutcomeUnits = new();
        protected List<Lesson> _lessons = new();
        protected List<Study> _studies = new();
        protected List<User> _users = new();

        protected readonly Guid _user1Id;

        protected readonly Guid _study1Id;

        protected readonly Guid _course1Id;
        protected readonly Guid _course1Version;

        protected readonly Guid _coursePlanning1Id;
        protected readonly Guid _coursePlanning1Version;

        protected readonly Guid _learningOutcomeUnit1Id;
        protected readonly Guid _learningOutcomeUnit1Version;

        protected readonly Guid _competency1Id;
        protected readonly Guid _competency1Version;

        protected readonly Guid _exam1Id;
        protected readonly Guid _exam1Version;

        protected readonly Guid _examinationEvent1Id;
        protected readonly Guid _examinationEvent1Version;

        protected readonly Guid _assessmentDimension1Id;
        protected readonly Guid _assessmentDimension1Version;

        protected readonly Guid _assessmentCriteria1Id;
        protected readonly Guid _assessmentCriteria1Version;

        protected readonly Guid _gradeDescription1Id;
        protected readonly Guid _gradeDescription1Version;

        protected readonly Guid _learningOutcome1Id;
        protected readonly Guid _learningOutcome1Version;

        protected readonly Guid _lesson1Id;
        protected readonly Guid _lesson1Version;

        public AbstractManagerSetup()
        {
            _study1Id = Guid.NewGuid();
            _studies = new()
            {
                new()
                {
                    Id = _study1Id,
                    Name = "Study 1",
                    IsDeleted = false
                }
            };

            _user1Id = Guid.NewGuid();
            _users = new()
            {
                new()
                {
                    Id= _user1Id,
                    Email = "user1@test.nl",
                    FirstName = "User",
                    LastName = "1",
                    Password = "password",
                    Role = Persistency.Database.Domain.Enums.Role.Teacher,
                    IsDeleted=false
                }
            };

            _course1Id = Guid.NewGuid();
            _course1Version = Guid.NewGuid();
            _courses = new()
            {
                new()
                {
                    Id = _course1Id,
                    Author = _user1Id,
                    StudyId = _study1Id,
                    DateOfCreation = DateTime.Now,
                    VersionCollection = _course1Version,
                    Name = "Course 1",
                    Code = "C1",
                    CollegeYear = DateTime.Now.Year,
                    CTE = 30,
                    Description = "Course 1 description",
                    IsFinalized = false,
                }
            };

            _coursePlanning1Id = Guid.NewGuid();
            _coursePlanning1Version = Guid.NewGuid();
            _coursePlannings = new()
            {
                new()
                {
                    Id = _coursePlanning1Id,
                    Author= _user1Id,
                    DateOfCreation= DateTime.Now,
                    VersionCollection = _coursePlanning1Version,
                    CourseId = _course1Id,
                }
            };

            _learningOutcomeUnit1Id = Guid.NewGuid();
            _learningOutcomeUnit1Version = Guid.NewGuid();
            _learningOutcomeUnits = new()
            {
                new()
                {
                    Id = _learningOutcomeUnit1Id,
                    VersionCollection = _learningOutcomeUnit1Version,
                    Author = _user1Id,
                    DateOfCreation = DateTime.Now,
                    CourseId= _course1Id,
                    Code = "LOU1",
                    Name = "LearningOutcomeUnit 1",
                    CTE = 15,
                    MinimumGrade = 5.5
                }
            };

            _competency1Id = Guid.NewGuid();
            _competency1Version = Guid.NewGuid();
            _competencies = new()
            {
                new()
                {
                    Id = _competency1Id,
                    VersionCollection = _competency1Version,
                    Author = _user1Id,
                    DateOfCreation = DateTime.Now,
                    CourseId = _course1Id,
                    LearningOutcomeUnitId = _learningOutcomeUnit1Id,
                    Name = "Competency 1",
                    Code = "C1"
                }
            };

            _exam1Id = Guid.NewGuid();
            _exam1Version = Guid.NewGuid();
            _exams = new()
            {
                new()
                {
                    Id= _exam1Id,
                    VersionCollection= _exam1Version,
                    Author= _user1Id,
                    DateOfCreation= DateTime.Now,
                    LearningOutcomeUnitId= _learningOutcomeUnit1Id,
                    Name = "Exam 1",
                    Code = "E1",
                    Type = Persistency.Database.Domain.Enums.ExamType.Casus,
                    Weight = 50,
                    MinimumGrade = 6
                }
            };

            _examinationEvent1Id = Guid.NewGuid();
            _examinationEvent1Version = Guid.NewGuid();
            _examinationEvents = new()
            {
                new()
                {
                    Id = _examinationEvent1Id,
                    VersionCollection= _examinationEvent1Version,
                    Author = _user1Id,
                    DateOfCreation = DateTime.Now,
                    CoursePlanningId = _coursePlanning1Id,
                    ExamId = _exam1Id,
                    Date = DateTime.Now.AddDays(1),
                    Type = "Casus",
                    Prerequisites = "Exam Prerequisites"
                }
            };

            _assessmentDimension1Id = Guid.NewGuid();
            _assessmentDimension1Version = Guid.NewGuid();
            _assessmentDimensions = new()
            {
                new()
                {
                    Id = _assessmentDimension1Id,
                    VersionCollection = _assessmentDimension1Version,
                    Author = _user1Id,
                    DateOfCreation= DateTime.Now,
                    ExamId = _exam1Id,
                    Description = "AssessmentDimension 1 Description",
                }
            };

            _assessmentCriteria1Id = Guid.NewGuid();
            _assessmentCriteria1Version = Guid.NewGuid();
            _assessmentCriterias = new()
            {
                new()
                {
                    Id = _assessmentCriteria1Id,
                    VersionCollection = _assessmentCriteria1Version,
                    Author= _user1Id,
                    DateOfCreation = DateTime.Now,
                    AssessmentDimensionId = _assessmentDimension1Id,
                    Name = "AssessmentCriteria 1",
                    Explanation = "AssessmentCriteria 1 Explanation",
                    MinimumGrade = 6,
                    Weight = 50
                }
            };

            _gradeDescription1Id = Guid.NewGuid();
            _gradeDescription1Version = Guid.NewGuid();
            _gradeDescriptions = new()
            {
                new()
                {
                    Id = _gradeDescription1Id,
                    VersionCollection= _gradeDescription1Version,
                    Author = _user1Id,
                    DateOfCreation = DateTime.Now,
                    AssessmentCriteriaId = _assessmentCriteria1Id,
                    Description = "GradeDescription 1",
                    Grade = 6
                }
            };

            _learningOutcome1Id = Guid.NewGuid();
            _learningOutcome1Version = Guid.NewGuid();
            _learningOutcomes = new()
            {
                new()
                {
                    Id = _learningOutcome1Id,
                    VersionCollection = _learningOutcome1Version,
                    Author= _user1Id,
                    DateOfCreation = DateTime.Now,
                    LearningOutcomeUnitId = _learningOutcomeUnit1Id,
                    Name = "LearningOutcome 1",
                    Description = "LearningOutcome 1 Description",
                    ExamId = _exam1Id
                }
            };

            _lesson1Id = Guid.NewGuid();
            _lesson1Version = Guid.NewGuid();
            _lessons = new()
            {
                new()
                {
                    Id = _lesson1Id,
                    VersionCollection = _lesson1Version,
                    Author = _user1Id,
                    DateOfCreation = DateTime.Now,
                    CoursePlanningId = _coursePlanning1Id,
                    Date = DateTime.Now.AddDays(1),
                    Name = "Lesson 1",
                    Description = "Lesson 1 Description",
                    Didactics = "Lesson 1 Dididactics",
                    LearningOutcomeId = _learningOutcome1Id
                }
            };
        }

        #region RepositorySessions
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
                    _assessmentCriterias.RemoveAll(y => y.Id == x.Id);
                    _assessmentCriterias.Add(toUpdate);
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
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<AssessmentDimension>())).Returns<AssessmentDimension>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _assessmentDimensions.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_assessmentDimensions)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _assessmentDimensions.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _assessmentDimensions.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<AssessmentDimension>())).Returns<AssessmentDimension>(x =>
            {
                var toUpdate = _assessmentDimensions.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _assessmentDimensions.RemoveAll(y => y.Id == x.Id);
                    _assessmentDimensions.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _assessmentDimensions.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _assessmentDimensions.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByExamIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _assessmentDimensions.Where(y => y.ExamId == x).ToList();

                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeExamIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _assessmentDimensions.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.ExamId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<ICompetencyRepositorySession> CreateCompetencyRepositorySession()
        {
            var repositorySessionMock = new Mock<ICompetencyRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<Competency>())).Returns<Competency>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _competencies.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_competencies)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _competencies.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _competencies.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<Competency>())).Returns<Competency>(x =>
            {
                var toUpdate = _competencies.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _competencies.RemoveAll(y => y.Id == x.Id);
                    _competencies.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _competencies.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _competencies.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByCourseIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _competencies.Where(y => y.CourseId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByLearningOutcomeUnitIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _competencies.Where(y => y.LearningOutcomeUnitId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeCourseIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _competencies.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.CourseId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeLearningOutcomeUnitIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _competencies.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.LearningOutcomeUnitId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<ICourseRepositorySession> CreateCourseRepositorySession()
        {
            var repositorySessionMock = new Mock<ICourseRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<Course>())).Returns<Course>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _courses.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_courses)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _courses.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _courses.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<Course>())).Returns<Course>(x =>
            {
                var toUpdate = _courses.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _courses.RemoveAll(y => y.Id == x.Id);
                    _courses.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _courses.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _courses.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByStudyIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _courses.Where(y => y.StudyId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<ICoursePlanningRepositorySession> CreateCoursePlanningRepositorySession()
        {
            var repositorySessionMock = new Mock<ICoursePlanningRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<CoursePlanning>())).Returns<CoursePlanning>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _coursePlannings.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_coursePlannings)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _coursePlannings.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _coursePlannings.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<CoursePlanning>())).Returns<CoursePlanning>(x =>
            {
                var toUpdate = _coursePlannings.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _coursePlannings.RemoveAll(y => y.Id == x.Id);
                    _coursePlannings.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _coursePlannings.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _coursePlannings.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByCourseIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _coursePlannings.FirstOrDefault(y => y.CourseId == x);
                return Task.FromResult(entity);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeCourseIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _coursePlannings.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.CourseId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<IExaminationEventRepositorySession> CreateExaminationEventRepositorySession()
        {
            var repositorySessionMock = new Mock<IExaminationEventRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<ExaminationEvent>())).Returns<ExaminationEvent>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _examinationEvents.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_examinationEvents)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _examinationEvents.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _examinationEvents.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<ExaminationEvent>())).Returns<ExaminationEvent>(x =>
            {
                var toUpdate = _examinationEvents.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _examinationEvents.RemoveAll(y => y.Id == x.Id);
                    _examinationEvents.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _examinationEvents.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _examinationEvents.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByCoursePlanningIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _examinationEvents.Where(y => y.CoursePlanningId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByExamIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _examinationEvents.Where(y => y.ExamId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeCoursePlanningIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _examinationEvents.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.CoursePlanningId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeExamIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _examinationEvents.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.ExamId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<IExamRepositorySession> CreateExamRepositorySession()
        {
            var repositorySessionMock = new Mock<IExamRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<Exam>())).Returns<Exam>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _exams.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_exams)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _exams.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _exams.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<Exam>())).Returns<Exam>(x =>
            {
                var toUpdate = _exams.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _exams.RemoveAll(y => y.Id == x.Id);
                    _exams.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _exams.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _exams.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByLearningOutcomeUnitIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _exams.Where(y => y.LearningOutcomeUnitId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeLearningOutcomeUnitIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _exams.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.LearningOutcomeUnitId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<IGradeDescriptionRepositorySession> CreateGradeDescriptionRepositorySession()
        {
            var repositorySessionMock = new Mock<IGradeDescriptionRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<GradeDescription>())).Returns<GradeDescription>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _gradeDescriptions.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_gradeDescriptions)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _gradeDescriptions.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _gradeDescriptions.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<GradeDescription>())).Returns<GradeDescription>(x =>
            {
                var toUpdate = _gradeDescriptions.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _gradeDescriptions.RemoveAll(y => y.Id == x.Id);
                    _gradeDescriptions.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _gradeDescriptions.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _gradeDescriptions.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByAssessmentCriteriaIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _gradeDescriptions.Where(y => y.AssessmentCriteriaId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeAssessmentCriteriaIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _exams.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.LearningOutcomeUnitId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<ILearningOutcomeRepositorySession> CreateLearningOutcomeRepositorySession()
        {
            var repositorySessionMock = new Mock<ILearningOutcomeRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<LearningOutcome>())).Returns<LearningOutcome>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _learningOutcomes.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_learningOutcomes)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _learningOutcomes.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _learningOutcomes.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<LearningOutcome>())).Returns<LearningOutcome>(x =>
            {
                var toUpdate = _learningOutcomes.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _learningOutcomes.RemoveAll(y => y.Id == x.Id);
                    _learningOutcomes.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _learningOutcomes.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _learningOutcomes.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByExamIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _learningOutcomes.Where(y => y.ExamId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByLearningOutcomeUnitIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _learningOutcomes.Where(y => y.LearningOutcomeUnitId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeExamIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _learningOutcomes.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.ExamId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeLearningOutcomeUnitIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _learningOutcomes.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.LearningOutcomeUnitId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<ILearningOutcomeUnitRepositorySession> CreateLearningOutcomeUnitRepositorySession()
        {
            var repositorySessionMock = new Mock<ILearningOutcomeUnitRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<LearningOutcomeUnit>())).Returns<LearningOutcomeUnit>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _learningOutcomeUnits.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_learningOutcomeUnits)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _learningOutcomeUnits.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _learningOutcomeUnits.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<LearningOutcomeUnit>())).Returns<LearningOutcomeUnit>(x =>
            {
                var toUpdate = _learningOutcomeUnits.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _learningOutcomeUnits.RemoveAll(y => y.Id == x.Id);
                    _learningOutcomeUnits.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _learningOutcomeUnits.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _learningOutcomeUnits.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByCourseIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _learningOutcomeUnits.Where(y => y.CourseId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeCourseIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _learningOutcomeUnits.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.CourseId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<ILessonRepositorySession> CreateLessonRepositorySession()
        {
            var repositorySessionMock = new Mock<ILessonRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<Lesson>())).Returns<Lesson>(x =>
            {
                x.Id = Guid.NewGuid();
                if (x.VersionCollection == Guid.Empty) x.VersionCollection = Guid.NewGuid();
                _lessons.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_lessons)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _lessons.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.GetByVersionIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _lessons.Where(y => y.VersionCollection == x).ToList();
                return Task.FromResult(entities);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<Lesson>())).Returns<Lesson>(x =>
            {
                var toUpdate = _lessons.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _lessons.RemoveAll(y => y.Id == x.Id);
                    _lessons.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _lessons.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _lessons.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByCoursePlanningIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _lessons.Where(y => y.CoursePlanningId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByLearningOutcomeIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entities = _lessons.Where(y => y.LearningOutcomeId == x).ToList();
                return Task.FromResult(entities);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeCoursePlanningIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _lessons.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.CoursePlanningId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.ChangeLearningOutcomeIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<Guid, Guid>((x, y) =>
            {
                var toChange = _lessons.FirstOrDefault(z => z.Id == x);
                if (toChange != null)
                {
                    toChange.LearningOutcomeId = y;
                }

                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<IEntityRepositorySession<Study>> CreateStudyRepositorySession()
        {
            var repositorySessionMock = new Mock<IEntityRepositorySession<Study>>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<Study>())).Returns<Study>(x =>
            {
                x.Id = Guid.NewGuid();
                _studies.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_studies)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _studies.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<Study>())).Returns<Study>(x =>
            {
                var toUpdate = _studies.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _studies.RemoveAll(y => y.Id == x.Id);
                    _studies.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _studies.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _studies.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();

            return repositorySessionMock;
        }

        protected Mock<IUserRepositorySession> CreateUserRepositorySession()
        {
            var repositorySessionMock = new Mock<IUserRepositorySession>();
            repositorySessionMock.Setup(x => x.SaveAsync(It.IsAny<User>())).Returns<User>(x =>
            {
                x.Id = Guid.NewGuid();
                _users.Add(x);
                return Task.FromResult(x);

            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_users)).Verifiable();
            repositorySessionMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var entity = _users.FirstOrDefault(y => y.Id == x);
                return Task.FromResult(entity);
            });
            repositorySessionMock.Setup(x => x.UpdateAsync(It.IsAny<User>())).Returns<User>(x =>
            {
                var toUpdate = _users.FirstOrDefault(y => y.Id == x.Id);
                if (toUpdate != null)
                {
                    toUpdate = x;
                    _users.RemoveAll(y => y.Id == x.Id);
                    _users.Add(toUpdate);
                }

                return Task.FromResult(toUpdate);
            }).Verifiable();
            repositorySessionMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).Returns<Guid>(x =>
            {
                var toDelete = _users.FirstOrDefault(y => y.Id == x);
                if (toDelete != null)
                    _users.Remove(toDelete);
                return Task.CompletedTask;
            }).Verifiable();
            repositorySessionMock.Setup(x => x.GetByEmailAsync(It.IsAny<string>())).Returns<string>(x =>
            {
                var entity = _users.FirstOrDefault(y => y.Email == x);
                return Task.FromResult(entity);
            }).Verifiable();

            return repositorySessionMock;
        }
        #endregion
    }
}