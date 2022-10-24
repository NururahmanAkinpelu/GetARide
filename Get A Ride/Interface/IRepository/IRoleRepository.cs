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
        public Task<Role> CreateRole(Role role, CancellationToken cancellationToken);
        public Task<Role> GetRoleById(int id, CancellationToken cancellationToken);
        public Task<Role> GetRoleByName(string name, CancellationToken cancellationToken);
        public Task<Role> UpdateRole(Role role, CancellationToken cancellationToken);
        public Task <ICollection<Role>> GetRolesByUserId(int userId, CancellationToken cancellationToken);
        public Task<ICollection<Role>> GetAll(CancellationToken cancellationToken);
    }
}
