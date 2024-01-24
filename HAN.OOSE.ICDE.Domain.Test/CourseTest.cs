using HAN.OOSE.ICDE.Domain.Test.Base;

namespace HAN.OOSE.ICDE.Domain.Test
{
    [TestClass]
    public class CourseTest : VersionedEntityTest<Course>
    {
        [TestMethod]
        public void Course_NotValid_Name()
        {
            var entity = new Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Name = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Course_NotValid_Code()
        {
            var entity = new Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.Code = "";

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Course_NotValid_CollegeYear()
        {
            var entity = new Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CollegeYear = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CollegeYear = -1;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Course_NotValid_CTE()
        {
            var entity = new Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CollegeYear = DateTime.Now.Year,
                CTE = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.CTE = -1;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Course_NotValid_StudyId()
        {
            var entity = new Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CollegeYear = DateTime.Now.Year,
                CTE = 10,
                StudyId = null
            };

            Assert.IsFalse(entity.IsValid());

            entity.StudyId = Guid.Empty;

            Assert.IsFalse(entity.IsValid());
        }

        [TestMethod]
        public void Course_Valid()
        {
            var entity = new Course()
            {
                Id = Guid.NewGuid(),
                Author = Guid.NewGuid(),
                VersionCollection = Guid.NewGuid(),
                DateOfCreation = DateTime.Now,
                Name = "Name",
                Code = "Code",
                CollegeYear = DateTime.Now.Year,
                CTE = 10,
                StudyId = Guid.NewGuid()
            };

            Assert.IsTrue(entity.IsValid());
        }
    }
}
