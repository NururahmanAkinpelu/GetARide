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
        public decimal? Price { get; set; }
       

    }

    public class UpdateOrderRequestModel
    {
        public OrderStatus Status { get; set; }
        public int? DriverId { get; set; }
        public int PassengerId { get; set; }
        public int PaymentId { get; set; }
    }

    public class OrderResponseModel:BaseResponse
    {
        public OrderDTO OrderDto { get; set; }
    }

    public class OrdersResponseModel:BaseResponse
    {
        public ICollection<OrderDTO> OrderDto { get; set; }
    }
}
