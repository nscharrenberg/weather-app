﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Measurement
    {
        public int Id { get; set; }
        public Station Station { get; set; }
        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public double FeelTemperature { get; set; }
        public double GroundTemperature { get; set; }
        public string WindDirection { get; set; }
        public int SunPower { get; set; }
        public double RainFallLastDay { get; set; }
    }
}