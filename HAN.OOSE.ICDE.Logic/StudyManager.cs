using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic
{
    public class StudyManager : IEntityManager<Study>
    {
        private readonly IEntityMapper<Domain.Study, Persistency.Database.Domain.Study> _mapper;
        private readonly IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.Study>, Persistency.Database.Domain.Study> _repository;

        public StudyManager(
            IEntityMapper<Study, Persistency.Database.Domain.Study> mapper, 
            IEntityRepository<IEntityRepositorySession<Persistency.Database.Domain.Study>, Persistency.Database.Domain.Study> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Study>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Study> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Study> SaveAsync(Study entity)
        {
            throw new NotImplementedException();
        }

        public Task<Study> UpdateAsync(Study entity)
        {
            throw new NotImplementedException();
        }
    }
}
