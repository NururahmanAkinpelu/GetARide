using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GetARide.Email.EmailDTO;

namespace GetARide.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailRequestModel email);
    }
}
