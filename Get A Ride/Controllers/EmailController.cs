using GetARide.DTO;
using GetARide.Email;
using GetARide.Interface.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static GetARide.Email.EmailDTO;

namespace GetARide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmailSender _email;

        public EmailController(IEmailSender email)
        {
            _email = email;
        }

        public async Task<IActionResult> SendEmail(EmailRequestModel email)
        {
            var send = await _email.SendEmail(email);
            if (send == true) return Ok(send);
            return BadRequest(send);
            
        }
    }
}