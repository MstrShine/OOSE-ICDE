using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class LearningOutcomeUnitRepositorySession : VersionedRepositorySessionBase<LearningOutcomeUnit>
    {
        protected override DbSet<LearningOutcomeUnit> Table => dataContext.LearningOutcomeUnits;

        public LearningOutcomeUnitRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
