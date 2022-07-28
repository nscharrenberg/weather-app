using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Measurement
    {
        public Measurement() { }

        public Measurement(Station station, DateTime timestamp, double temperature)
        {
            this.Station = station;
            this.Timestamp = timestamp;
            this.Temperature = temperature;
        }

        public Measurement(Station station, DateTime timestamp, double temperature, double feelTemperature, double groundTemperature, string windDirection, int sunPower, double rainFallLastDay)
        {
            Station = station;
            Timestamp = timestamp;
            Temperature = temperature;
            FeelTemperature = feelTemperature;
            GroundTemperature = groundTemperature;
            WindDirection = windDirection;
            SunPower = sunPower;
            RainFallLastDay = rainFallLastDay;
        }

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
