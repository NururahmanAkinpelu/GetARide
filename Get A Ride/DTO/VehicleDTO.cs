using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Model { get; set; }
        public string Documents { get; set; }
        public string PlateNumber { get; set; }
        public int DriverId { get; set; }
    }

    public class VehicleRequestModel
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Model { get; set; }
        public string Documents { get; set; }
        public string PlateNumber { get; set; }
        public int DriverId { get; set; }
    }

    public class UpdateVehicleRequestModel
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Model { get; set; }
        public string Documents { get; set; }
        public string PlateNumber { get; set; }
    }

    public class VehicleResponseModel : BaseResponse
    {
        public VehicleDTO Data { get; set; }
    }

    public class VehiclesResponseModel : BaseResponse
    {
        public ICollection<VehicleDTO> Data { get; set; }
    }
}
