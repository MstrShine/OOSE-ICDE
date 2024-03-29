﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Logic.Test.Managers.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class LearningOutcomeUnitManagerTest : VersionedEntityManagerTest<ILearningOutcomeUnitManager, Domain.LearningOutcomeUnit>
    {
        protected override Guid VersionIdForBasicTests => _learningOutcomeUnit1Version;

        protected override int VersionListCount => _learningOutcomeUnits.Count;

        protected override Guid IdForBasicTest => _learningOutcomeUnit1Id;

        protected override int ListCount => _learningOutcomeUnits.Count;

        public LearningOutcomeUnitManagerTest()
        {
            var learningOutcomeUnitSession = CreateLearningOutcomeUnitRepositorySession();
            var learningOutcomeUnitRepository = new Mock<IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit>>();
            learningOutcomeUnitRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeUnitSession.Object);

            var competencySession = CreateCompetencyRepositorySession();
            var competencyRepository = new Mock<IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency>>();
            competencyRepository.Setup(x => x.CreateSession()).Returns(competencySession.Object);

            var learningOutcomeSession = CreateLearningOutcomeRepositorySession();
            var learningOutcomeRepository = new Mock<IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome>>();
            learningOutcomeRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeSession.Object);

            var examSession = CreateExamRepositorySession();
            var examRepository = new Mock<IEntityRepository<IExamRepositorySession, Persistency.Database.Domain.Exam>>();
            examRepository.Setup(x => x.CreateSession()).Returns(examSession.Object);


            _manager = new LearningOutcomeUnitManager(
                learningOutcomeUnitRepository.Object,
                new LearningOutcomeUnitMap(),
                competencyRepository.Object,
                learningOutcomeRepository.Object,
                examRepository.Object);
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
            var learningOutcomeUnits = await _manager.GetByCourseIdAsync(_course1Id);

            Assert.IsTrue(learningOutcomeUnits.All(x => x.CourseId == _course1Id));
            Assert.AreEqual(_learningOutcomeUnits.Count(x => x.CourseId == _course1Id), learningOutcomeUnits.Count);
        }

        [TestMethod]
        public async Task GetByCourseId_IdNotFound()
        {
            var learningOutcomeUnits = await _manager.GetByCourseIdAsync(Guid.NewGuid());

            Assert.AreEqual(0, learningOutcomeUnits.Count);
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

        protected override LearningOutcomeUnit Construct()
        {
            return new()
            {
                Author = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                CourseId = Guid.NewGuid(),
                Name = "Name",
                Code = "Code",
                CTE = 0,
                MinimumGrade = 0,
            };
        }
    }
}
