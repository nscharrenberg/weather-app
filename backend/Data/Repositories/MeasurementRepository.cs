using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class MeasurementRepository : Repository<Measurement>, IMeasurementRepository
    {
        public MeasurementRepository(StationContext context) : base(context)
        {
        }

        public IEnumerable<Measurement> GetByStationAndTimestampRange(Station station, DateTime start, DateTime end)
        {
            return context.Set<Measurement>().Where((Measurement measurement) => (measurement.Station.Equals(station) && measurement.Timestamp >= start && measurement.Timestamp <= end)).ToList();
        }
    }
}
