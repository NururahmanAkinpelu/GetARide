using GetARide.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IUserRepository
    {
        public Task<User> GetUserAsync(int id, CancellationToken cancellationToken);
        public Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        public Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);
        public Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken);
        public Task<ICollection<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        
       
    }
}
