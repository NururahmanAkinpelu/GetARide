using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities.Base
{
    public class AuditableEntity:BaseEntity, ISoftDelete, IAuditableEntity
    {
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
        public int LastModifiedBy { get; set; }
    }
}
