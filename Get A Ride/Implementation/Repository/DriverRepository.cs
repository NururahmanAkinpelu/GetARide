using GetARide.Context;
using GetARide.Entities;
using GetARide.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly ApplicationContext _context;
        public DriverRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Driver>> GetAllDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _context.Drivers.Include(d => d.User).ToListAsync();
            return drivers;
        }

        public async Task<ICollection<Driver>> GetApprovedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsApproved == true).ToListAsync();
            return drivers;
        }

        public async Task<ICollection<Driver>> GetDeactivaedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsDeleted == true).ToListAsync();
            return drivers;
        }

        public async Task<ICollection<Driver>> GetActivatedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsDeleted == false).ToListAsync();
            return drivers;
        }

        public async Task<Driver> GetDriverByEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (email == null)
            {
                throw new ArgumentNullException();
            }
            var passenger = await _context.Drivers.Include(d => d.User).SingleOrDefaultAsync(d => d.User.Email == email, cancellationToken);
            return passenger;
        }

        public async Task<Driver> GetDriverById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var passenger = await _context.Drivers.Include(d => d.User).SingleOrDefaultAsync(d => d.Id == id, cancellationToken);
            return passenger;
        }

        public async Task<ICollection<Driver>> GetUnapprovedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsApproved == false).ToListAsync();
            return drivers;
        }

        public async Task<Driver> GetDriverWithVehicles(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _context.Drivers.Include(d => d.User).Include(v => v.Vehicles).
                SingleOrDefaultAsync(d => d.Id == id);
            return driver;
        }

        public async Task<Driver> RegisterDriver(Driver driver, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Drivers.AddAsync(driver, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return driver;
        }

        public async Task<Driver> UpdateDriver(Driver driver, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
             _context.Update(driver);
            await _context.SaveChangesAsync(cancellationToken);
            return driver;
        }

        public async Task <ICollection<Driver>> GetAvailableDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _context.Drivers.Include(d => d.Vehicles).Where(d => d.IsAvailable == true).ToListAsync();
            return drivers;
        }
    }
}
