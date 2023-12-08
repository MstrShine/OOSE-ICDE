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
    public class CompetencyRepositorySession : VersionedRepositorySessionBase<Competency>
    {
        protected override DbSet<Competency> Table => dataContext.Competencies;

        public CompetencyRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

    }
}
