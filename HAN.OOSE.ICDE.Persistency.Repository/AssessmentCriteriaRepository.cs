using HAN.OOSE.ICDE.Persistency.Database;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Repository
{
    public class AssessmentCriteriaRepository : VersionedRepositoryBase<AssessmentCriteria>
    {
        protected override DbSet<AssessmentCriteria> Table => dataContext.AssessmentCriterias;

        public AssessmentCriteriaRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
