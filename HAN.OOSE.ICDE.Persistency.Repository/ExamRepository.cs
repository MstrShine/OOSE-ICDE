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
    public class ExamRepository : VersionedRepositoryBase<Exam>
    {
        protected override DbSet<Exam> Table => dataContext.Exams;
        
        public ExamRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
