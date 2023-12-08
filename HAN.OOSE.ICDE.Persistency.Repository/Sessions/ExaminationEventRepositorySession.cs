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
    public class ExaminationEventRepositorySession : VersionedRepositorySessionBase<ExaminationEvent>
    {
        protected override DbSet<ExaminationEvent> Table => dataContext.ExaminationEvents;

        public ExaminationEventRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
