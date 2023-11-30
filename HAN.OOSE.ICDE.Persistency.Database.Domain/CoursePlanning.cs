﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class CoursePlanning : DBEntity
    {
        public List<Lesson> Lessons { get; set; }

        public List<ExaminationEvent> Examinations { get; set; }
    }
}