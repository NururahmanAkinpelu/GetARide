using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class UserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserResponseModel : BaseResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public ICollection<RoleDTO> Roles { get; set; } = new HashSet<RoleDTO>();
    }
    public class LoginResponse 
    {
        public string Token { get; set; }
        public UserResponseModel Data { get; set; }
    }
}
