namespace Domain.Interfaces
{
    public interface IStationRepository : IRepository<Station>
    {
        Station? GetByStationId(int stationId);
        Station? FindOrCreate(Station station);
    }
}
