using GetARide.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IAdminRepository
    {
        public Task<Admin> CreateAdmin(Admin admin);
        public Task<Admin> UpdateAdmin(Admin admin);
        /*public Task<Admin> DeleteAdmin(int id, CancellationToken cancellationToken);*/
        public Task<Admin> GetAdminByEmail(string email );
        public Task<IList<Admin>> GetAllActivatedAdmin( );
        public Task<IList<Admin>> GetAllDeactivatedAdmin( );
        public Task<ICollection<Admin>> GetAllAdmins( );
        public Task<Admin> GetAdminById(int id);

    }
}
