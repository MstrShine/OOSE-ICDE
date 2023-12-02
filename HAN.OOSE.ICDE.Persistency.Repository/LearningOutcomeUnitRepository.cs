using HAN.OOSE.ICDE.Persistency.Database;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository
{
    public class LearningOutcomeUnitRepository : VersionedRepositoryBase<LearningOutcomeUnit>
    {
        protected override DbSet<LearningOutcomeUnit> Table => dataContext.LearningOutcomeUnits;

        public LearningOutcomeUnitRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
