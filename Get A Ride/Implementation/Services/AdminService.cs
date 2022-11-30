using GetARide.Context;
using GetARide.Entities;
using GetARide.Entities.Identity;
using GetARide.DTO;
using GetARide.Interface.IRepository;
using GetARide.Interface.IService;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ApplicationContext _context;

        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IRoleRepository roleRepository, ApplicationContext context)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _context = context;
        }
        
        public async Task<BaseResponse> ActivateAdmin(int id )
        {
            var admin = await _adminRepository.GetAdminById(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin not found",
                    Success = false
                };
            }
            else if (admin != null && admin.IsDeleted == false)
            {
                return new BaseResponse
                {
                    Message = "Admin already activated",
                    Success = true
                };
            }
            admin.IsDeleted = false;
            await _adminRepository.UpdateAdmin(admin);
            return new BaseResponse
            {
                Message = "Admin activated",
                Success = true
            };
        }

        public async Task<BaseResponse> DeActivateAdmin(int id )
        {
            var admin = await _adminRepository.GetAdminById(id);

            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin not found",
                    Success = false
                };
            }
            admin.IsDeleted = true;
            await _adminRepository.UpdateAdmin(admin);
            return new BaseResponse
            {
                Message = "admin deleted ",
                Success = true
            };

        }

        public async Task<AdminResponseModel> GetAdmin(int id)
        {
            var admin = await _adminRepository.GetAdminById(id);
            if (admin == null)
            {
                return new AdminResponseModel
                {
                    Message = "admin not found",
                    Success = false
                };
            }
            var adminDto = new AdminDTO
            {
                Id = admin.Id,
                FullName = $"{admin.FirstName} {admin.LastName}",
                PhoneNumber = admin.PhoneNumber,
                Email = admin.Email,
                
            };
            return new AdminResponseModel
            {
                Message = "admin Successfully retrieved",
                Success = true,
                Data = adminDto
            };
        }

        public async Task<AdminsResponseModel> GetAllActiveAdmins( )
        {
            var admins = await _adminRepository.GetAllActivatedAdmin();
            if (admins.Count == 0)
            {
                return new AdminsResponseModel
                {
                    Message = "No admin is activated",
                    Success = false
                };
            }
            var adminDtos = admins.Select(a => new AdminDTO
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}",
                PhoneNumber = a.PhoneNumber,
                Email = a.Email
            }).ToList();

            return new AdminsResponseModel
            {
                Message = "admin retrieved successfully",
                Success = true,
                AdminDTOs = adminDtos
            };
        }

        public async Task<AdminsResponseModel> GetAllDeactivatedAdmins( )
        {
            var admins = await _adminRepository.GetAllDeactivatedAdmin();
            if (admins.Count == 0)
            {
                return new AdminsResponseModel
                {
                    Message = "No admin is deactivated",
                    Success = false
                };
            }
            var adminDtos = admins.Select(a => new AdminDTO
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}",
                PhoneNumber = a.PhoneNumber,
                Email = a.Email
            }).ToList();

            return new AdminsResponseModel
            {
                Message = "admins retrieved successfully",
                Success = true,
                AdminDTOs = adminDtos
            };

        }

        public async Task<AdminsResponseModel> GetAllAdmins( )
        {
            var admins = await _adminRepository.GetAllAdmins();
            if (admins.Count == 0)
            {
                return new AdminsResponseModel
                {
                    Message = "No admin found",
                    Success = false
                };
            }

            var adminDtos = admins.Select(a => new AdminDTO
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}",
                PhoneNumber = a.PhoneNumber,
                Email = a.Email
            }).ToList();

            return new AdminsResponseModel
            {
                Message = "admin retrieved successfully",
                Success = true,
                AdminDTOs = adminDtos
            };
        }

        public async Task<BaseResponse> RegisterAdmin(AdminRequestModel model )
        {
            var u = await _adminRepository.GetAdminByEmail(model.Email);
            if (u != null)
            {
                return new BaseResponse
                {
                    Message = "email already exist",
                    Success = false,
                };
            }
            var user = new User
            {
                FullName = $"{model.FirstName} {model.LastName}",
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Email = model.Email
            };
            Console.WriteLine($"{user.Password}");

            var addUser = await _userRepository.CreateUserAsync(user);
            var role = await _roleRepository.GetRoleByName("Admin");
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Role not found",
                    Success = false
                };
            }
            var userRole = new UserRoles
            {
                UserId = addUser.Id,
                RoleId = role.Id
            };
            _context.UserRoles.Add(userRole);

            var updateUser = await _userRepository.UpdateUserAsync(user);

            var admin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserId = addUser.Id,
            };
            var addadmin = await _adminRepository.CreateAdmin(admin);

            admin.CreatedBy = addadmin.Id;
            admin.LastModifiedBy = addadmin.Id;
            admin.IsDeleted = false;

            await _adminRepository.UpdateAdmin(admin);
            return new BaseResponse
            {
                Message = "admin Successfully registered",
                Success = true,
            };
        }

        public async Task<BaseResponse> UpdateAdmin(UpdateAdminRequestModel model, int id )
        {
            var admin = await _adminRepository.GetAdminById(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin not found",
                    Success = false
                };
            }
            var getUser = await _userRepository.GetUserByEmailAsync(model.Email);
            if (getUser == null)
            {
                return new BaseResponse
                {
                    Message = "User not found",
                    Success = false
                };
            }
            getUser.Email = model.Email;
            getUser.Password = model.Password;
            await _userRepository.UpdateUserAsync(getUser);

            admin.User.Email = model.Email ?? admin.User.Email;
            admin.User.Password = model.Password ?? admin.User.Password;
            admin.FirstName = model.FirstName ?? admin.FirstName;
            admin.LastName = model.LastName ?? admin.LastName;
            admin.PhoneNumber = model.PhoneNumber ?? admin.PhoneNumber;
            await _adminRepository.UpdateAdmin(admin);
            return new BaseResponse
            {
                Message = "Admin sucessfully updated",
                Success = true
            };
        }

        public async Task<AdminResponseModel> GetAdminByEmail(string email )
        {
            var admin = await _adminRepository.GetAdminByEmail(email);
            if (admin == null)
            {
                return new AdminResponseModel
                {
                    Message = "admin not found",
                    Success = false
                };
            }
            var adminDto = new AdminDTO
            {
                Id = admin.Id,
                FullName = $"{admin.FirstName} {admin.LastName}",
                PhoneNumber = admin.PhoneNumber,
                Email = admin.Email,

            };
            return new AdminResponseModel
            {
                Message = "admin Successfully retrieved",
                Success = true,
                Data = adminDto
            };
        }
    }
}
