using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping
{
    public class UserMap : IEntityMapper<Domain.User, Persistency.Database.Domain.User>
    {
        public Persistency.Database.Domain.User FromEntity(Domain.User entity)
        {
            var user = new Persistency.Database.Domain.User()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Role = (Persistency.Database.Domain.Enums.Role)entity.Role
            };

            return user;
        }

        public Domain.User ToEntity(Persistency.Database.Domain.User dbEntity)
        {
            var user = new Domain.User()
            {
                Id = dbEntity.Id,
                Email = dbEntity.Email,
                Password = dbEntity.Password,
                FirstName = dbEntity.FirstName,
                LastName = dbEntity.LastName,
                Role = (Domain.Enums.Role)dbEntity.Role
            };

            return user;
        }
    }
}
