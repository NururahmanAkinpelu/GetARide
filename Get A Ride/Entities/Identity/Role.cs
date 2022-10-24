using GetARide.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities.Identity
{
    public class Role:AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRoles> UserRole { get; set; } = new HashSet<UserRoles>();
    }
}
