using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private StationContext context;

        public UnitOfWork(StationContext context)
        {
            this.context = context;
            this.Station = new StationRepository(this.context);
            this.Measurement = new MeasurementRepository(this.context);
        }

        public IStationRepository Station { get; private set; }

        public IMeasurementRepository Measurement { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
