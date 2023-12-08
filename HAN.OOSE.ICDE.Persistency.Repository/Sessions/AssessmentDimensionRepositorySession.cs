using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class AssessmentDimensionRepositorySession : VersionedRepositorySessionBase<AssessmentDimension>
    {
        protected override DbSet<AssessmentDimension> Table => dataContext.AssessmentDimensions;

        public AssessmentDimensionRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
