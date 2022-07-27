using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Station
    {
        public Station(int stationId, string name, string region)
        {
            StationId = stationId;
            Name = name;
            Region = region;
            Measurements = new List<Measurement>();
        }

        public int Id { get; }
        public int StationId { get; private set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public List<Measurement> Measurements { get; set; }

    }
}
