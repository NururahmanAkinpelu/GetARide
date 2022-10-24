using GetARide.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities.Identity
{
    public class User:AuditableEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Admin Admin { get; set; }
        public Passenger Passenger { get; set; }
        public Driver Driver { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; } = new HashSet<UserRoles>();
    }
}
