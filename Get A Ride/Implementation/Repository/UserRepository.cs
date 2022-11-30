using GetARide.Context;
using GetARide.Entities.Identity;
using GetARide.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Repository
{
    public class UserRepository:IUserRepository
    {
        public ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ICollection<User>> GetAllUsersAsync()
        {
    
            var users = await _context.Users.Include(u => u.Id).ToListAsync();
            return users;

        }

        public async Task<User> GetUserAsync(int id )
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email )
        {
            var user = await _context.Users.Include(x => x.UserRoles).ThenInclude(x =>x.Role).Where(x => x.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user )
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /*public async Task<User> DeactivateUser(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }*/
    }
}
