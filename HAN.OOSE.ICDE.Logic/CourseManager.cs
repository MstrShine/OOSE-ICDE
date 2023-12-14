using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Base;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic
{
    public class CourseManager : VersionedEntityManager<Domain.Course, Persistency.Database.Domain.Course, ICourseRepositorySession>, ICourseManager
    {
        public CourseManager(
            IEntityRepository<ICourseRepositorySession, Persistency.Database.Domain.Course> repository, 
            IEntityMapper<Domain.Course, Persistency.Database.Domain.Course> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<Course>> GetByStudyIdAsync(Guid studyId)
        {
            if(studyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studyId));
            }

            var courses = new List<Course>();
            using(var session = _repository.CreateSession()) 
            { 
                var dbList = await session.GetByStudyId(studyId);
                courses = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return courses;
        }
    }
}
