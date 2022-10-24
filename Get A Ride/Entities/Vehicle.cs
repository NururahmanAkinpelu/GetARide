using GetARide.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities.Identity
{
    public class Vehicle:AuditableEntity
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Model { get; set; }
        public string Documents { get; set; }
        public string PlateNumber { get; set; }
        public bool IsApproved { get; set; }
        public decimal BasePrice { get; set; }
        public int DriverId { get; set; }
        public  Driver Driver  { get; set; }

    }
}
