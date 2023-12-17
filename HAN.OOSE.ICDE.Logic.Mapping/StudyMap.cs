using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class StudyMap : IEntityMapper<Domain.Study, Persistency.Database.Domain.Study>
    {
        public Persistency.Database.Domain.Study FromEntity(Domain.Study entity)
        {
            return new Persistency.Database.Domain.Study()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Domain.Study ToEntity(Persistency.Database.Domain.Study dbEntity)
        {
            return new Domain.Study()
            {
                Id = dbEntity.Id,
                Name = dbEntity.Name,
            };
        }
    }
}
