using GetARide.Context;
using GetARide.Entities.Identity;
using GetARide.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationContext _context;
        public VehicleRepository(ApplicationContext context)
        {
            _context = context;
        }
        /*public async Task<Vehicle> DeleteVehicle(Vehicle vehicle, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync(cancellationToken);
            return vehicle;
        }*/

        public async  Task<Vehicle> RegisterVehicle(Vehicle vehicle )
        {
            await _context.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async  Task<Vehicle> UpdateVehicle(Vehicle vehicle )
        {
          
            _context.Update(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> GetVehicleById(int id )
        {
            
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(v => v.Id == id);
            return vehicle;
        }

        public async  Task<Vehicle> GetVehicleByPlateNumber(string plateNumber )
        {
            var vehicle = await _context.Vehicles.Include(v => v.Driver).SingleOrDefaultAsync(v => v.PlateNumber == plateNumber);
            return vehicle;
        }

        public async Task<ICollection<Vehicle>> GetAllDriversVehicles(int driverId )
        {
            var vehicles = await _context.Vehicles.Include(v => v.Driver).Where(v => v.Driver.UserId == driverId).ToListAsync();
            return vehicles;
        }

        public async Task<Vehicle> DeleteVehicle(Vehicle vehicle )
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }
    }
}
