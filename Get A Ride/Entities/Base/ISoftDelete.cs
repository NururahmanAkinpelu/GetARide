using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Entities.Base
{
    interface ISoftDelete
    {
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
