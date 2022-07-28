using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStationRepository Station { get; }
        IMeasurementRepository Measurement { get; }

        int Save();
    }
}
