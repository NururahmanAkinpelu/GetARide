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
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserResponseModel> Login(UserRequestModel model, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email, cancellationToken);

            if (user.IsDeleted == true)
            {
                return new UserResponseModel
                {
                    Message = "Your acct has been deactivated so you can't log-in.",
                    Success = false
                };
            }
         
            else if (user != null && model.Password == user.Password)
            {
               //var roles = await _roleRepository.GetRolesByUserId(user.Id, cancellationToken);
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
            return new UserResponseModel
            {
                Message = "Invalid email or password",
                Success = false
            };
        }
    }
}
