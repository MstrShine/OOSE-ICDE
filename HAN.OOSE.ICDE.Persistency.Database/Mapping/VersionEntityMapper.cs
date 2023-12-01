using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public abstract class VersionEntityMapper<T> : EntityMapper<T> where T : VersionDBEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.VersionCollection);
            builder.Property(x => x.DateOfCreation).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Author).WithMany();
        }
    }
}
