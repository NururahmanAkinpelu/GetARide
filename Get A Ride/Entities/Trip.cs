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
        public DateTime? StartTime { get; set; } 
        public DateTime? EndTime { get; set; } 
        public DateTime? Date { get; set; }
        public TripType Type { get; set; }
        public TripStatus Status { get; set; }
        public int? Distance { get; set; }
        public int? Time { get; set; }
        public Order Order { get; set; }
    }
}
