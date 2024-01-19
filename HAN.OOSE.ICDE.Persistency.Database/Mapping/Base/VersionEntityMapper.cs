using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping.Base
{
    public abstract class VersionEntityMapper<T> : EntityMapper<T> where T : VersionedDBEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.VersionCollection);
            builder.Property(x => x.DateOfCreation).HasDefaultValueSql("GETDATE()");

            builder.HasOne<User>().WithMany().HasForeignKey(x => x.Author).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
