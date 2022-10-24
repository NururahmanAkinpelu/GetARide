using GetARide.Authentication;
using GetARide.DTO;
using GetARide.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthentication _auth;

        public UserController(IUserService userService, IJWTAuthentication auth)
        {
            _userService = userService;
            _auth = auth;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var login = await _userService.Login(model, cancellationToken);
            if (login.Success == false) return BadRequest(login);

            var token = _auth.GenerateToken(login, cancellationToken);
            var response = new LoginResponse
            {
                Data = login,
                Token = token
            };
            return Ok(response);
        }
    }
}
