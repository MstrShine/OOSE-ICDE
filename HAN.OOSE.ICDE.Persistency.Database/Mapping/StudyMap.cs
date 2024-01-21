using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class StudyMap : EntityMapper<Study>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Study> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasMany<Course>().WithOne().HasForeignKey(x => x.StudyId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
