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
        public async Task<Role> CreateRole(Role role )
        {
         
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role> GetRoleById(int id )
        {
   
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var role = await _context.Roles.FirstOrDefaultAsync(u => u.Id == id);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
        
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role> GetRoleByName(string name )
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
            return role;
        }

        public async Task<ICollection<Role>> GetRolesByUserId(int userId )
        {
      
            var roles = await _context.Roles.Where(x => x.Id == userId).Select(r => new Role
            {
                Name = r.Name,
                Description = r.Description
            }).ToListAsync();
            return roles;
        }

        public async Task<ICollection<Role>> GetAll( )
        {
           
            var role = await _context.Roles.Include(r => r.UserRole).ToListAsync();
            return role;
        }

        public async Task<ICollection<UserRoles>> GetUserRolesByUserid(int userId )
        {
    
            var userRoles = await _context.UserRoles.Include(x => x.Role).Where(x => x.UserId == userId).ToListAsync();
            return userRoles;          
        }
    }
}
