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
        public Task<BaseResponse> CreateRole(RoleRequestModel model );
        public Task<BaseResponse> UpdateRole(RoleRequestModel model, int id );
        public Task<RolesResponseModel> GetRolesByUserId(int userId );
        public Task<RolesResponseModel> GetAllRoles( );

    }
}
