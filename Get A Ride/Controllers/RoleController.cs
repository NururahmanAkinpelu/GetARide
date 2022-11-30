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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleservice;

        public RoleController(IRoleService roleService)
        {
            _roleservice = roleService;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> Create([FromForm] RoleRequestModel model)
        {
            var response = await _roleservice.CreateRole(model);
            if (response.Success == true) return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetRoleByUserId")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var response = await _roleservice.GetRolesByUserId(userId);
            if (response.Success == true) return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roleservice.GetAllRoles();
            if (response.Success == true) return Ok(response);

            return BadRequest(response);
        }
        
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> Update([FromBody] RoleRequestModel model, int id)
        {
            var response = await _roleservice.UpdateRole(model, id);
            if (response.Success == true) return Ok(response);

            return BadRequest(response);
        }

    }
}
