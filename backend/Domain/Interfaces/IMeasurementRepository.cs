namespace Domain.Interfaces
{
    public interface IMeasurementRepository : IRepository<Measurement>
    {
        IEnumerable<Measurement> GetByStationAndTimestampRange(Station station, DateTime start, DateTime end);
        void AddByStationAndNewTimestamp(Measurement measurement);
    }
}
