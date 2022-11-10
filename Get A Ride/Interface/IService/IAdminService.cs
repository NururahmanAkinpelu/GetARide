using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface IAdminService
    {
        public Task<BaseResponse> RegisterAdmin(AdminRequestModel model, CancellationToken cancellationToken);
        public Task<BaseResponse> UpdateAdmin(UpdateAdminRequestModel model, int id, CancellationToken cancellationToken);
        public Task<AdminResponseModel> GetAdmin(int id, CancellationToken cancellationToken);
        public Task<AdminResponseModel> GetAdminByEmail(string email, CancellationToken cancellationToken);
        public Task<AdminsResponseModel> GetAllAdmins(CancellationToken cancellationToken);
        public Task<BaseResponse> ActivateAdmin(int id, CancellationToken cancellationToken);
        public Task<BaseResponse> DeActivateAdmin(int id, CancellationToken cancellationToken);
        public Task<AdminsResponseModel> GetAllActiveAdmins(CancellationToken cancellationToken);
        public Task<AdminsResponseModel> GetAllDeactivatedAdmins(CancellationToken cancellationToken);
    }
}
