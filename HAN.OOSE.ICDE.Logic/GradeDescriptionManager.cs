﻿using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic
{
    public class GradeDescriptionManager : VersionedEntityManager<Domain.GradeDescription, Persistency.Database.Domain.GradeDescription>
    {
        public GradeDescriptionManager(
            IEntityRepository<IVersionedEntityRepositorySession<Persistency.Database.Domain.GradeDescription>, Persistency.Database.Domain.GradeDescription> repository, 
            IEntityMapper<Domain.GradeDescription, Persistency.Database.Domain.GradeDescription> mapper) : base(repository, mapper)
        {
        }
    }
}