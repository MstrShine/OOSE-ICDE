using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public abstract class EntityMapper<T> : IEntityTypeConfiguration<T> where T : DBEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            ConfigureExtension(builder);
        }

        public abstract void ConfigureExtension(EntityTypeBuilder<T> builder);
    }
}
