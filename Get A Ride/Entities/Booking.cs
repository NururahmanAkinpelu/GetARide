using GetARide.Entities.Base;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetARide.Entities
{
    public class Booking:AuditableEntity
    {
        public string ReferenceNumber { get; set; }
        public int? DriverId { get; set; }

        [EnumDataType(typeof(BookingStatus))]
        public BookingStatus Status { get; set; }
        public int PassengerId { get; set; }
        public Payment Payment { get; set; }
        public Driver Driver { get; set; }
        public Passenger Passenger { get; set; }
        public Trip Trip { get; set; }
    }
}
