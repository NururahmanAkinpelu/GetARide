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
        public async Task<ICollection<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var users = await _context.Users.Include(u => u.Id).ToListAsync();
            return users;

        }

        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var user = await _context.Users.Include(x => x.UserRoles).ThenInclude(x =>x.Role).Where(x => x.Email == email).FirstOrDefaultAsync( cancellationToken);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
