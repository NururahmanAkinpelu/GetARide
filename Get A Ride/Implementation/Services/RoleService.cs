using GetARide.Entities.Identity;
using GetARide.DTO;
using GetARide.Interface.IRepository;
using GetARide.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse> CreateRole(RoleRequestModel model)
        {
            var role = await _roleRepository.GetRoleByName(model.Name);
            if (role != null)
            {
                return new BaseResponse
                {
                    Message = "Role already exists",
                    Success = false
                };
            }

            var newRole = new Role
            {
                Name = model.Name,
                Description = model.Description
            };

            await _roleRepository.CreateRole(newRole);

            return new BaseResponse
            {
                Message = "Role created succesfully",
                Success = true
            };
        }

        public async Task<RolesResponseModel> GetAllRoles()
        {
            var roles = await _roleRepository.GetAll();
            var roleDtos = roles.Select(r => new RoleDTO 
            { 
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
            }).ToList();
          /*  if (roles == null)
            {
                return new RolesResponseModel
                {
                    Message = "No roles exist",
                    Succes = false
                };
            }*/
            return new RolesResponseModel
            {
                Message = "List gotten",
                Success = true,
                Datas = roleDtos
            };
        }

        public async Task<BaseResponse> UpdateRole(RoleRequestModel model,int id )
        {
            var role = await _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return new RoleResponseModel
                {
                    Message = "Role not found",
                    Success = false
                };
            }

            role.Name = model.Name;
            role.Description = model.Description;
            await _roleRepository.UpdateRole(role);

            return new BaseResponse
            {
                Message = "Role Updated",
                Success = true
            };
        }

        public async Task<RolesResponseModel> GetRolesByUserId(int userId)
        {
            var roles = await _roleRepository.GetRolesByUserId(userId);
            var roleDtos = roles.Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
            }).ToList();

            return new RolesResponseModel
            {
                Message = "List gotten",
                Success = true,
                Datas = roleDtos
            };
        }
    }
}
