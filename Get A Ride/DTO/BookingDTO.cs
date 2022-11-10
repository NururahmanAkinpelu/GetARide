using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }

/*        [EnumDataType(typeof(BookingStatus))]
        [JsonConverter(typeof(JsonStringEnumConverter))]*/
        public BookingStatus Status { get; set; }
        public int PassengerId { get; set; }
        public int? DriverId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int TripId { get; set; }
       

    }

    public class BookingRequestModel
    {
        public string ReferenceNumber { get; set; }
        public BookingStatus Status { get; set; }
        //public int? DriverId { get; set; }
        public int PassengerId { get; set; }
        public int TripId { get; set; }
        //public Trip Trip { get; set; }
    }

    public class UpdateBookingRequestModel
    {
        public BookingStatus Status { get; set; }
        public int? DriverId { get; set; }
        public int PassengerId { get; set; }
        public int PaymentId { get; set; }
    }

    public class BookingResponseModel:BaseResponse
    {
        public BookingDTO BookingDto { get; set; }

    }

    public class BookingsResponseModel:BaseResponse
    {
        public ICollection<BookingDTO> BookingDtos { get; set; }
    }
}
