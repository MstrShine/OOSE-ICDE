using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository
{
    public class AssessmentDimensionRepository : EntityRepository<IVersionedEntityRepositorySession<AssessmentDimension>, AssessmentDimension>
    {
        public AssessmentDimensionRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
