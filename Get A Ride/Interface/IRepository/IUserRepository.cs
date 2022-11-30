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
        public Task<User> GetUserAsync(int id  );
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> CreateUserAsync(User user );
        public Task<User> UpdateUserAsync(User user );
        public Task<ICollection<User>> GetAllUsersAsync();
        /*public Task<User> DeactivateUser(User user, CancellationToken cancellationToken);*/
    }
}
