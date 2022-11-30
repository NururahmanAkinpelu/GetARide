using GetARide.Context;
using GetARide.Entities;
using GetARide.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Repository
{
    public class AdminRepository:IAdminRepository
    {
        public ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Admin> CreateAdmin(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            _context.Update(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> GetAdminById(int id )
        {
            var admin = await _context.Admins.Include(x => x.User).Where(a => a.Id == id).SingleOrDefaultAsync();
            if (admin == null)
            {
                return null;
            }
            return admin;
        }

        public async Task<Admin> GetAdminByEmail(string email )
        {
            var admin = await _context.Admins.Include(x => x.User).SingleOrDefaultAsync(a => a.Email == email);
            if (admin == null)
            {
                return null;
            }
            return admin;
        }

        public async Task<IList<Admin>> GetAllActivatedAdmin()
        {
            var admin = await _context.Admins.Include(x => x.User).Where(x => x.IsDeleted == false).ToListAsync();
            return admin;
        }
        public async Task<IList<Admin>> GetAllDeactivatedAdmin()
        {
            var admin = await _context.Admins.Include(x => x.User ).Where(x => x.IsDeleted == true).ToListAsync();
            return admin;
        }

        public async Task<ICollection<Admin>> GetAllAdmins()
        {
            var admins = await _context.Admins.Include(a => a.User).ToListAsync();
            return admins;
        }
    }
}
