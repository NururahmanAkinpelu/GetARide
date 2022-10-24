using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class PassengerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class PassengerRequestModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateAPassengerRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PassengerResponseModel : BaseResponse
    {
        public PassengerDTO Data { get; set; }
    }

    public class PassengersResponseModel : BaseResponse
    {
        public ICollection<PassengerDTO> PassengerDTOs { get; set; }
    }

}
