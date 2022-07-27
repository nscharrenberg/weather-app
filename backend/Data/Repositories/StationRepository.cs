using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(StationContext context) : base(context)
        {
        }

        public Station? FindOrCreate(Station station)
        {
            Station? found = GetByStationId(station.StationId);

            if (found != null)
            {
                return found;
            }

            Add(station);
            return null;
        }

        public Station? GetByStationId(int stationId)
        {
            return context.Set<Station>().Find((Station station) => station.StationId == stationId);    
        }

      

    }
}
