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

        public async Task<ICollection<Driver>> GetApprovedDrivers()
        {
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsApproved == true).ToListAsync();
            return drivers;
        }

        public async Task<ICollection<Driver>> GetDeactivaedDrivers()
        {
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsDeleted == true).ToListAsync();
            return drivers;
        }

        public async Task<ICollection<Driver>> GetActivatedDrivers( )
        {
            
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsDeleted == false).ToListAsync();
            return drivers;
        }

        public async Task<Driver> GetDriverByEmail(string email)
        {
            
            if (email == null)
            {
                throw new ArgumentNullException();
            }
            var passenger = await _context.Drivers.Include(d => d.User).SingleOrDefaultAsync(d => d.User.Email == email);
            return passenger;
        }

        public async Task<Driver> GetDriverById(int id )
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var passenger = await _context.Drivers.Include(d => d.User).SingleOrDefaultAsync(d => d.Id == id);
            return passenger;
        }

        public async Task<ICollection<Driver>> GetUnapprovedDrivers()
        {
            var drivers = await _context.Drivers.Include(d => d.User).Where(d => d.IsApproved == false).ToListAsync();
            return drivers;
        }

        public async Task<Driver> GetDriverWithVehicles(int id)
        {
            var driver = await _context.Drivers.Include(d => d.User).Include(v => v.Vehicles).
                SingleOrDefaultAsync(d => d.Id == id);
            return driver;
        }

        public async Task<Driver> RegisterDriver(Driver driver )
        {

            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task<Driver> UpdateDriver(Driver driver)
        {
             _context.Update(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task <ICollection<Driver>> GetAvailableDrivers( )
        {
            var drivers = await _context.Drivers.Include(d => d.Vehicles).Where(d => d.IsAvailable == true).ToListAsync();
            return drivers;
        }

        public async Task <Driver> GetDriverByUserId(int userId)
        {

            var driver = await _context.Drivers.FirstOrDefaultAsync(p => p.UserId == userId);
            return driver;
        }

    }
}
