using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Station
    {
        public Station() { }
        public Station(int stationId, string name, string region)
        {
            StationId = stationId;
            Name = name;
            Region = region;
            Measurements = new List<Measurement>();
        }

        public int Id { get; set; }
        public int StationId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public List<Measurement> Measurements { get; set; }

    }
}
