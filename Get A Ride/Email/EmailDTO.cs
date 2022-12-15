using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Email
{
    public class EmailDTO
    {
        public class EmailRequestModel
        {
            public string ReceiverName { get; set; }
            public string ReceiverEmail { get; set; }
            public string Message { get; set; }
            public string Subject { get; set; }
        }
        public class EmailResponseModel
        {
            public string Message { get; set; }
        }
    }
}
