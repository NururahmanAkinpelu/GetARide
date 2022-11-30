using GetARide.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> RegisterVehicle(Vehicle vehicle );
        public Task<Vehicle> UpdateVehicle(Vehicle vehicle );
        public Task<Vehicle> DeleteVehicle(Vehicle vehicle );
        public Task<Vehicle> GetVehicleById(int id );
        public Task<Vehicle> GetVehicleByPlateNumber(string plateNumber );
        public Task<ICollection<Vehicle>> GetAllDriversVehicles(int driverId);
        
    }
}
