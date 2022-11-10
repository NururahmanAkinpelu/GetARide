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
        public Task<Vehicle> RegisterVehicle(Vehicle vehicle, CancellationToken cancellationtoken);
        public Task<Vehicle> UpdateVehicle(Vehicle vehicle, CancellationToken cancellationToken);
       /* public Task<Vehicle> DeleteVehicle(Vehicle vehicle, CancellationToken cancellationToken);*/
        public Task<Vehicle> GetVehicleById(int id, CancellationToken cancellationToken);
        public Task<Vehicle> GetVehicleByPlateNumber(string plateNumber, CancellationToken cancellationToken);
        public Task<ICollection<Vehicle>> GetAllDriversVehicles(int driverId, CancellationToken cancellationToken);
    }
}
