using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        ///     Get the Measurements of a station between a certain timestamp range.
        /// </summary>
        /// <param name="station"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<Measurement> GetByStationAndTimestampRange(Station station, DateTime start, DateTime end)
        {
            return context.Set<Measurement>().Where((Measurement measurement) => (measurement.Station.Equals(station) && measurement.Timestamp >= start && measurement.Timestamp <= end)).ToList();
        }

        /// <summary>
        ///     Add a new measurement record if the timestamp and station are not already in the system.
        /// </summary>
        /// <param name="measurement"></param>
        public void AddByStationAndNewTimestamp(Measurement measurement)
        {
            try
            {
                context.Set<Measurement>().Where((Measurement localMeasurement) => localMeasurement.Timestamp.Equals(measurement.Timestamp) && localMeasurement.Station.StationId.Equals(measurement.Station.StationId)).First();
            } catch (InvalidOperationException e)
            {
                Add(measurement);
            }
        }
    }
}
