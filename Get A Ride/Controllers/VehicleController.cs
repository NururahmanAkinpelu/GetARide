using GetARide.DTO;
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

namespace GetARide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VehicleController(IVehicleService vehicleService, IWebHostEnvironment webHostEnvironment)
        {
            _vehicleService = vehicleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("RegisterVehicle")]
        public async Task<IActionResult> RegisterVehicle([FromBody]VehicleRequestModel model)
        {
            var vehicle = await _vehicleService.RegisterVehicle(model, model.DriverId);
            if (vehicle.Success == true) return Ok(vehicle);

            return BadRequest(vehicle);
        }

        [HttpPut("UpdateVehicle/{id}")]
        public async Task<IActionResult> UpdateVehicle([FromForm] UpdateVehicleRequestModel model, [FromRoute] int id )
        {
            var files = HttpContext.Request.Form;

            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo info = new FileInfo(file.FileName);
                    string documents = Guid.NewGuid().ToString() + info.Extension;
                    string path = Path.Combine(imageDirectory, documents);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    model.Documents = (documents);
                }
            }

            var vehicle = await _vehicleService.UpdateVehicle(model, id);
            if (vehicle.Success == true) return Ok(vehicle);

            return BadRequest(vehicle);
        }

        [HttpDelete("Deletevehicle/{id}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int id )
        {
            var vehicle = await _vehicleService.DeleteVehicle(id);
            if (vehicle.Success == true) return Ok(vehicle);

            return BadRequest(vehicle);
        }

        [HttpGet("GetAllDriversVehicle/{driverId}")]
        public async Task<IActionResult> GetAllDriversVehicle([FromRoute] int driverId )
        {
            var vehicle = await _vehicleService.GetAllDriversVehicle(driverId);
            if (vehicle.Success == true) return Ok(vehicle);

            return BadRequest(vehicle);

        }

        [HttpGet("GetVehiclesCount/{driverId}")]
        public async Task<IActionResult> GetVehiclesCount([FromRoute] int driverId)
        {
            var count = await _vehicleService.GetVehiclesCount(driverId);
            return Ok(count);
        }
    }
}

