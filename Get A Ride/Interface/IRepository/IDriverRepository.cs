using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IDriverRepository
    {
        public Task<Driver> RegisterDriver(Driver driver, CancellationToken cancellationToken);
        public Task<Driver> UpdateDriver(Driver driver, CancellationToken cancellationToken);
        public Task<Driver> GetDriverById(int id, CancellationToken cancellationToken);
        public Task<Driver> GetDriverByEmail(string email, CancellationToken cancellationToken);
        public Task<Driver> GetDriverWithVehicles(int id, CancellationToken cancellationToken);
        public Task<ICollection<Driver>> GetAvailableDrivers( CancellationToken cancellationToken);
        public Task<ICollection<Driver>> GetAllDrivers(CancellationToken cancellationToken);
        public Task<ICollection<Driver>> GetApprovedDrivers(CancellationToken cancellationToken);
        public Task<ICollection<Driver>> GetUnapprovedDrivers(CancellationToken cancellationToken);
        public Task<ICollection<Driver>> GetActivatedDrivers(CancellationToken cancellationToken);
        public Task<ICollection<Driver>> GetDeactivaedDrivers(CancellationToken cancellationToken);
    }
}
