﻿using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Test.Managers
{
    [TestClass]
    public class LearningOutcomeManagerTest : VersionedEntityManagerTest<ILearningOutcomeManager, Domain.LearningOutcome>
    {
        public LearningOutcomeManagerTest()
        {
            var learningOutcomeSession = CreateLearningOutcomeRepositorySession();
            var learningOutcomeRepository = new Mock<IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome>>();
            learningOutcomeRepository.Setup(x => x.CreateSession()).Returns(learningOutcomeSession.Object);

            var lessonSession = CreateLessonRepositorySession();
            var lessonRepository = new Mock<IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson>>();
            lessonRepository.Setup(x => x.CreateSession()).Returns(lessonSession.Object);

            _manager = new LearningOutcomeManager(learningOutcomeRepository.Object, new LearningOutcomeMap(), lessonRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByExamId_EmptyGuid()
        {
            await _manager.GetByExamIdAsync(Guid.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByLearningOutcomeUnitId_EmptyGuid()
        {
            await _manager.GetByLearningOutcomeUnitIdAsync(Guid.Empty);
        }
    }
}
