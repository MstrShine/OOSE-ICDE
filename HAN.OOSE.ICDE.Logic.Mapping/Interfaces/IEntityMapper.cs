using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Mapping.Interfaces
{
    public interface IEntityMapper<T, Y> where T : Entity where Y : DBEntity
    {
        T ToEntity(Y dbEntity);

        Y FromEntity(T entity);
    }
}
