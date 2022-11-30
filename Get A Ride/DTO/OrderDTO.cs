using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }

/*        [EnumDataType(typeof(OrderStatus))]
        [JsonConverter(typeof(JsonStringEnumConverter))]*/
        public OrderStatus Status { get; set; }
        public DateTime? Date { get; set; }
        public  string OrderType { get; set; }
        public int PassengerId { get; set; }
        public int? DriverId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Type { get; set; }
        public int TripId { get; set; }
       

    }

    public class BookingRequestModel
    {
        public string ReferenceNumber { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? Date { get; set; }
        public int BookingType { get; set; }
        public int PassengerId { get; set; }
        public int TripId { get; set; }
    }

    public class UpdateBookingRequestModel
    {
        public OrderStatus Status { get; set; }
        public int? DriverId { get; set; }
        public int PassengerId { get; set; }
        public int PaymentId { get; set; }
    }

    public class BookingResponseModel:BaseResponse
    {
        public OrderDTO OrderDto { get; set; }

    }

    public class BookingsResponseModel:BaseResponse
    {
        public ICollection<OrderDTO> OrderDto { get; set; }
    }
}
