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
    public class AdminRepository:IAdminRepository
    {
        public ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Admin> CreateAdmin(Admin admin, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Admins.AddAsync(admin, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return admin;
        }

        public async Task<Admin> UpdateAdmin(Admin admin, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Update(admin);
            await _context.SaveChangesAsync(cancellationToken);
            return admin;
        }

        public async Task<Admin> GetAdminById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var admin = await _context.Admins.Include(x => x.User).SingleOrDefaultAsync(a => a.User.Id == id, cancellationToken);
            if (admin == null)
            {
                return null;
            }
            return admin;
        }

        public async Task<Admin> GetAdminByEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (email == null)
            {
                throw new ArgumentNullException();
            }
            var admin = await _context.Admins.Include(x => x.User).SingleOrDefaultAsync(a => a.User.Email == email, cancellationToken);
            if (admin == null)
            {
                return null;
            }
            return admin;
        }

        public async Task<IList<Admin>> GetAllActivatedAdmin(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _context.Admins.Include(x => x.User).Where(x => x.IsDeleted == false).ToListAsync();
            return admin;
        }
        public async Task<IList<Admin>> GetAllDeactivatedAdmin(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _context.Admins.Include(x => x.User ).Where(x => x.IsDeleted == true).ToListAsync();
            return admin;
        }

        public async Task<ICollection<Admin>> GetAllAdmins(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admins = await _context.Admins.Include(a => a.User).ToListAsync();
            return admins;
        }
    }
}
