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
        public Task<Driver> RegisterDriver(Driver driver);
        public Task<Driver> UpdateDriver(Driver driver);
        public Task<Driver> GetDriverById(int id);
        public Task<Driver> GetDriverByEmail(string email);
        public Task<Driver> GetDriverWithVehicles(int id);
        public Task<ICollection<Driver>> GetAvailableDrivers();
        public Task<ICollection<Driver>> GetApprovedDrivers( );
        public Task<ICollection<Driver>> GetUnapprovedDrivers( );
        public Task<ICollection<Driver>> GetActivatedDrivers( );
        public Task<ICollection<Driver>> GetDeactivaedDrivers( );
        public Task<Driver> GetDriverByUserId(int userId );
    }
}
