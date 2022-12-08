using GetARide.Entities;
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
        public string Mode { get; set; }
        public string Colour { get; set; }
        public string PlateNumber { get; set; }
        public string Document { get; set; }
        public VehicleType Type { get; set; }
        public int DriverId { get; set; }
    }
    
   
    public class VehicleRequestModel
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string PlateNumber { get; set; }
        public string Mode { get; set; }
        public string Document { get; set; }
        public VehicleType Type { get; set; }
        public int DriverId { get; set; }
    }

    public class UpdateVehicleRequestModel
    {
        public string Name { get; set; }
        public string Mode { get; set; }
        public string Colour { get; set; }
        public string PlateNumber { get; set; }
        public string Document { get; set; }
    }

    public class VehicleResponseModel : BaseResponse
    {
        public VehicleDTO VehicleDto { get; set; }
    }

    public class VehiclesResponseModel : BaseResponse
    {
        public ICollection<VehicleDTO> VehicleDtos { get; set; }
    }
}
