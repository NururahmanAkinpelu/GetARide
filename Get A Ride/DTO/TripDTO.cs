using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class TripDTO
    {
        public int Id { get; set; }
        public string PickUpLocation { get; set; }
        public string DropLocation { get; set; }
        public DateTime? StartTime { get; set; } 
        public DateTime? EndTime { get; set; } 
        public DateTime? Date { get; set; } 
        public TripType TripType { get; set; }
        public int? Distance { get; set; }
        public int? Time { get; set; }


    }

    public class TripRequestModel
    {
        public string PickUpLocation { get; set; }
        public string DropLocation { get; set; }
        public DateTime? Date { get; set; }
        public int TripType { get; set; }        
    }

    public class UpdateTripRequestModel
    {
        public int? Distance { get; set; }
        public int? Time { get; set; }
    }

    public class TripResponseModel : BaseResponse
    {
        public TripDTO TripDto { get; set; }
    }

    public class TripsResponseModel : BaseResponse
    {
        public ICollection<TripDTO> TripDtos { get; set; }
    }
}
