﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Domain
{
    public class ExaminationEvent : Entity
    {
        public string Type { get; set; }

        public List<DateTime> Dates { get; set; }

        public string Prerequisites { get; set; }
    }
}