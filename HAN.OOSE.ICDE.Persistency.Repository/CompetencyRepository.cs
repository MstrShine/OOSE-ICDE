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
    public class CompetencyRepository : VersionedRepositoryBase<Competency>
    {
        protected override DbSet<Competency> Table => dataContext.Competencies;

        public CompetencyRepository(DataContext dataContext) : base(dataContext)
        {
        }

    }
}
