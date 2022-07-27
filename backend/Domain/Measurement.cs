using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Measurement
    {
        public int Id { get; }
        public Station Station { get; private set; }
        public double Temperature { get; set; }
        public double FeelTemperature { get; set; }
        public double GroundTemperature { get; set; }
        public string WindDirection { get; set; }
        public int SunPower { get; set; }
        public double RainFallLastDay { get; set; }
    }
}
