﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CheckInTimes
    {
        public int ID { get; set; }
        public int Barcode { get; set; }
        public string Name { get; set; }
        public DateTime CheckInTime { get; set; }
    }
}
