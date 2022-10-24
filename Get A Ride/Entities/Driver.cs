using GetARide.Entities.Base;
using GetARide.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities
{
    public class Driver:AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string License { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsApproved { get; set; }
        public bool IsAvailable { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
