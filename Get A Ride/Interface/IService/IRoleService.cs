using GetARide.Entities.Identity;
using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface IRoleService
    {
        public Task<BaseResponse> CreateRole(RoleRequestModel model, CancellationToken cancellationToken);
        public Task<BaseResponse> UpdateRole(RoleRequestModel model, int id,  CancellationToken cancellationToken);
        public Task<RolesResponseModel> GetRolesByUserId(int userId, CancellationToken cancellationToken);
        public Task<RolesResponseModel> GetAllRoles(CancellationToken cancellationToken);

    }
}
