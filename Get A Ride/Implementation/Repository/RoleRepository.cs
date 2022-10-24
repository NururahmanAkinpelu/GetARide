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
    public class RoleRepository:IRoleRepository
    {
        public ApplicationContext _context;
        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Role> CreateRole(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Roles.AddAsync(role, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return role;
        }
        public async Task<Role> GetRoleById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var role = await _context.Roles.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        public async Task<Role> UpdateRole(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role> GetRoleByName(string name, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == name, cancellationToken);
            return role;
        }

        public async Task<ICollection<Role>> GetRolesByUserId(int userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var roles = await _context.Roles.Where(x => x.Id == userId).Select(r => new Role
            {
                Name = r.Name,
                Description = r.Description
            }).ToListAsync(cancellationToken);
            return roles;
        }

        public async Task<ICollection<Role>> GetAll(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var role = await _context.Roles.Include(r => r.UserRole).ToListAsync();
            return role;
        }
    }
}
