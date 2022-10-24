using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    
    public class AdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class UpdateAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AdminResponseModel : BaseResponse
    {
        public AdminDTO Data { get; set; }
    }

    public class AdminsResponseModel : BaseResponse
    {
        public ICollection<AdminDTO> AdminDTOs { get; set; }
    }
}
