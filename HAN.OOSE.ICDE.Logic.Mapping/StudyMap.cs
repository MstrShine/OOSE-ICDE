using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class StudyMap : IEntityMapper<Domain.Study, Persistency.Database.Domain.Study>
    {
        public Persistency.Database.Domain.Study FromEntity(Domain.Study entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new Persistency.Database.Domain.Study()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsDeleted = entity.IsDeleted,
            };
        }

        public Domain.Study ToEntity(Persistency.Database.Domain.Study dbEntity)
        {
            if (dbEntity == null)
            {
                throw new ArgumentNullException(nameof(dbEntity));
            }

            return new Domain.Study()
            {
                Id = dbEntity.Id,
                Name = dbEntity.Name,
                IsDeleted = dbEntity.IsDeleted,
            };
        }
    }
}
