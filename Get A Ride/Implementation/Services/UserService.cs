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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDriverRepository _driverRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IDriverRepository driverRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _driverRepository = driverRepository;
        }

        public async Task<UserResponseModel> Login(UserRequestModel model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user.IsDeleted == true)
            {
                return new UserResponseModel
                {
                    Message = "Your acct has been deactivated so you can't log-in.",
                    Success = false
                };
            }
         
            else if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
               var userRoles = await _roleRepository.GetUserRolesByUserid(user.Id);
                foreach (var item in userRoles )
                {
                    var role = await _roleRepository.GetRoleById(item.RoleId);
                    if (role.Name == "Driver")
                    {
                        var driver = await _driverRepository.GetDriverByEmail(model.Email);
                        if (driver.IsApproved == false)
                        {
                            return new UserResponseModel
                            {
                                Id = user.Id,
                                Message = "You have not been approved, so you can't log-in yet.",
                                Success = false
                            };
                        }
                    }
                    return new UserResponseModel
                    {

                        Id = user.Id,
                        Email = user.Email,
                        Roles = user.UserRoles.Select(x => new RoleDTO
                        {
                            Id = x.RoleId,
                            Name = x.Role.Name,
                            Description = x.Role.Description
                        }).ToList(),
                        Message = "Successfully logged in",
                        Success = true
                    };
                }

            }
            return new UserResponseModel
            {
                Message = "Invalid email or password",
                Success = false
            };
        }
    }
}


