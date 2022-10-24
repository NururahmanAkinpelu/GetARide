using GetARide.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class DriverDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string License { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }

    public class DriverRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Licence { get; set; }
    }

    public class UpdateDriverRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Licence { get; set; }
    }

    public class DriverResponseModel:BaseResponse
    {
        public DriverDTO Data { get; set; }
    }

    public class DriversResponseModel : BaseResponse
    {
        public ICollection<DriverDTO> Data { get; set; }
    }
}
