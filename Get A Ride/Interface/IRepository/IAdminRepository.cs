using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IAdminRepository
    {
        public Task<Admin> CreateAdmin(Admin admin, CancellationToken cancellationToekn);
        public Task<Admin> UpdateAdmin(Admin admin, CancellationToken cancellationToken);
        /*public Task<Admin> DeleteAdmin(int id, CancellationToken cancellationToken);*/
        public Task<Admin> GetAdminByEmail(string email, CancellationToken cancellationToken);
        public Task<IList<Admin>> GetAllActivatedAdmin(CancellationToken cancellationToken);
        public Task<IList<Admin>> GetAllDeactivatedAdmin(CancellationToken cancellationToken);
        public Task<ICollection<Admin>> GetAllAdmins(CancellationToken cancellationToken);
        public Task<Admin> GetAdminById(int id, CancellationToken cancellationToken);

    }
}
