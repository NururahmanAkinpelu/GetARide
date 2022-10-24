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

        public async  Task<Vehicle> RegisterVehicle(Vehicle vehicle, CancellationToken cancellationtoken)
        {
            cancellationtoken.ThrowIfCancellationRequested();
            await _context.AddAsync(vehicle, cancellationtoken);
            await _context.SaveChangesAsync(cancellationtoken);
            return vehicle;
        }

        public async  Task<Vehicle> UpdateVehicle(Vehicle vehicle, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Update(vehicle);
            await _context.SaveChangesAsync(cancellationToken);
            return vehicle;
        }

        public async Task<Vehicle> GetVehicleById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);
            return vehicle;
        }

        public async  Task<Vehicle> GetVehicleByPlateNumber(string plateNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var vehicle = await _context.Vehicles.Include(v => v.Driver).SingleOrDefaultAsync(v => v.PlateNumber == plateNumber, cancellationToken);
            return vehicle;
        }
    }
}
