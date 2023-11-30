using HAN.OOSE.ICDE.Persistency.Database.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database
{
    public class DataContext : DbContext
    {
        private readonly string _conntectionString;

        public DataContext(IConfiguration configuration) : base()
        {
            _conntectionString = configuration.GetConnectionString("Default");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly((typeof(DataContext).Assembly));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_conntectionString, b =>
            {
                b.EnableRetryOnFailure();
            }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            if (Debugger.IsAttached)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}
