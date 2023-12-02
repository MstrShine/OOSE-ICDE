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
    public class CoursePlanningRepository : VersionedRepositoryBase<CoursePlanning>
    {
        protected override DbSet<CoursePlanning> Table => dataContext.CoursePlannings;

        public CoursePlanningRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
