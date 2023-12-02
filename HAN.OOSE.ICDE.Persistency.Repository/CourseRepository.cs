﻿using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository
{
    public class CourseRepository : EntityRepository<IVersionedEntityRepositorySession<Course>, Course>
    {
        public CourseRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
