using GetARide.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities
{
    public class Trip:AuditableEntity
    {
        public string PickUpLocation { get; set; }
        public string DropLocation { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; } = DateTime.UtcNow;
        public TripType Type { get; set; }
        public TripStatus Status { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}
