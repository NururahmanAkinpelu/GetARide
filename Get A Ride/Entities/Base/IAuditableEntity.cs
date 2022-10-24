using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities.Base
{
    interface IAuditableEntity
    {
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public int LastModifiedBy { get; set; }
    }
}
