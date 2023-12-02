using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class ExamRepositorySession : VersionedRepositorySessionBase<Exam>
    {
        protected override DbSet<Exam> Table => dataContext.Exams;

        public ExamRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
