using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public abstract class EntityMapper<T> : IEntityTypeConfiguration<T> where T : DBEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            ConfigureExtension(builder);
        }

        public abstract void ConfigureExtension(EntityTypeBuilder<T> builder);
    }
}
