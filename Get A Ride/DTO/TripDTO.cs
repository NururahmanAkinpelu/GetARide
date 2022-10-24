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
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime EndTime { get; set; } = DateTime.UtcNow;
        public TripType TripType { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }

    public class TripRequestModel
    {
        public string PickUpLocation { get; set; }
        public string DropLocation { get; set; }
        public TripType TripType { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
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
