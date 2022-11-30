using GetARide.Entities;
using GetARide.DTO;
using GetARide.Interface.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IAdminService adminService, IWebHostEnvironment webHostEnvironment)
        {
            _adminService = adminService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromForm] AdminRequestModel model)
        {
            var admin = await _adminService.RegisterAdmin(model);

            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpPut("UpdateAdmin/{id}")]
        public async Task<IActionResult> UpdateAdmin([FromRoute]UpdateAdminRequestModel model,[FromRoute]int id )
        {
            var admin = await _adminService.UpdateAdmin(model, id);
            if (admin.Success == false) return BadRequest(admin);

            return Ok(admin);
        }

        [HttpGet("GetAdminInfo/{id}")]
        public async Task<IActionResult> GetAdminInfo([FromRoute]int id )
        {
            var admin = await _adminService.GetAdmin(id);
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAllAdmins( )
        {
            var admin = await _adminService.GetAllAdmins();
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpPut("ActivateAdmin/{id}")]
        public async Task<IActionResult> ActivateAdmin([FromRoute]int id)
        {
            var admin = await _adminService.ActivateAdmin(id);
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpPut("DeactivateAdmin/{id}")]
        public async Task<IActionResult> DectivateAdmin([FromRoute] int id )
        {
            var admin = await _adminService.DeActivateAdmin(id);
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpGet("GetAllActivatedAdmins")]
        public async Task<IActionResult> GetAllActivatedAdmins ( )
        {
            var admins = await _adminService.GetAllActiveAdmins();
            if (admins.Success == true) return Ok(admins);

            return BadRequest(admins);
        }

        [HttpGet("GetAllDeactivatedAdmins")]
        public async Task<IActionResult> GetAllDeactivatedAdmins ()
        {
            var admins = await _adminService.GetAllDeactivatedAdmins();
            if (admins.Success == true) return Ok(admins);

            return BadRequest(admins);
        }
    }
}
