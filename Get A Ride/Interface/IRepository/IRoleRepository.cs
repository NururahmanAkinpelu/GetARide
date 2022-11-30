using GetARide.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IRoleRepository
    {
        public Task<Role> CreateRole(Role role );
        public Task<Role> GetRoleById(int id );
        public Task<Role> GetRoleByName(string name );
        public Task<Role> UpdateRole(Role role );
        public Task <ICollection<Role>> GetRolesByUserId(int userId );
        public Task<ICollection<Role>> GetAll( );
        public Task<ICollection<UserRoles>> GetUserRolesByUserid(int userId);
    }
}
