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
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(StationContext context) : base(context)
        {
        }

        public override IEnumerable<Station> GetAll()
        {
            return context.Station.Include(s => s.Measurements).ToList();
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
            return context.Set<Station>().Where((Station station) => station.StationId == stationId).Include(s => s.Measurements).First();    
        }

      

    }
}
