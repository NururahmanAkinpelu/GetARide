using GetARide.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities
{
    public class Payment:AuditableEntity
    {
        public decimal Amount { get; set; }
        public Guid ReferenceNumber { get; set; }
        public bool Ispayed { get; set; }
        public Booking Booking { get; set; }
        public int Bookingid { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
