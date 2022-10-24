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
        public async Task<IActionResult> RegisterAdmin([FromForm] AdminRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _adminService.RegisterAdmin(model, cancellationToken);

            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpPut("UpdateAdmin/{id}")]
        public async Task<IActionResult> UpdateAdmin([FromRoute]UpdateAdminRequestModel model,[FromRoute]string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _adminService.UpdateAdmin(model, email, cancellationToken);
            if (admin.Success == false) return BadRequest(admin);

            return Ok(admin);
        }

        [HttpGet("GetAdminInfo/{id}")]
        public async Task<IActionResult> GetAdminInfo([FromRoute]int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _adminService.GetAdmin(id, cancellationToken);
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAllAdmins(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _adminService.GetAllAdmins(cancellationToken);
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpPost("ActivateAdmin")]
        public async Task<IActionResult> ActivateAdmin([FromRoute]string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _adminService.ActivateAdmin(email, cancellationToken);
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpPost("DeactivateAdmin/{id}")]
        public async Task<IActionResult> DectivateAdmin([FromRoute] string emai, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _adminService.DeActivateAdmin(emai, cancellationToken);
            if (admin.Success == true) return Ok(admin);

            return BadRequest(admin);
        }

        [HttpGet("GetAllActivatedAdmins")]
        public async Task<IActionResult> GetAllActivatedAdmins (CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admins = await _adminService.GetAllActiveAdmins(cancellationToken);
            if (admins.Success == true) return Ok(admins);

            return BadRequest(admins);
        }

        [HttpGet("GetAllDeactivatedAdmins")]
        public async Task<IActionResult> GetAllDeactivatedAdmins (CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admins = await _adminService.GetAllDeactivatedAdmins(cancellationToken);
            if (admins.Success == true) return Ok(admins);

            return BadRequest(admins);
        }
    }
}
