using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class AssessmentCriteriaRepositorySession : VersionedRepositorySessionBase<AssessmentCriteria>
    {
        protected override DbSet<AssessmentCriteria> Table => dataContext.AssessmentCriterias;

        public AssessmentCriteriaRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
