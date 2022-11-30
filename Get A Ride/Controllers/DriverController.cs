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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IVehicleService _vehicleService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DriverController(IDriverService driverService, IVehicleService vehicleService, IWebHostEnvironment webHostEnvironment)
        {
            _driverService = driverService;
            _vehicleService = vehicleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("RegisterDriver")]
        public async Task<IActionResult> RegisterDriver([FromForm] DriverRequestModel model)
        {
           /* var files = HttpContext.Request.Form;
            int i = 0;

            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo info = new FileInfo(file.FileName);
                    string image = Guid.NewGuid().ToString() + info.Extension;
                    string path = Path.Combine(imageDirectory, image);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    if (i == 0) model.Image = image;
                    else model.Licence = image;
                    i++;
                }
            }*/
            var driver = await _driverService.RegisterDriver(model);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpPut("UpdateDriver")]
        public async Task<IActionResult> UpdateDriver ([FromForm] UpdateDriverRequestModel model, [FromRoute]string email )
        {
            var files = HttpContext.Request.Form;

            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo info = new FileInfo(file.FileName);
                    string image = Guid.NewGuid().ToString() + info.Extension;
                    string path = Path.Combine(imageDirectory, image);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    model.Image = (image);
                }
            }
            var driver = await _driverService.UpdateDriver(model,email);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpPut("ApproveDriver/{id}")]
        public async Task<IActionResult> ApprovedDriver([FromRoute]int id)
        {
            var driver = await _driverService.ApproveDriver(id);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpPut("ActivateDriver/{id}")]
        public async Task<IActionResult> ActivateDriver([FromRoute] int id )
        {
            var driver = await _driverService.ActivateDriver(id);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpPut("Deactivatedriver/{id}")]
        public async Task<IActionResult> DeactivateDriver([FromRoute] int id )
        {
            var driver = await _driverService.DeactivateDriver(id);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetApprovedDrivers")]
        public async Task<IActionResult> GetApprovedDrivers( )
        {
            var drivers = await _driverService.GetApprovedDrivers();
            if (drivers.Success == true) return Ok(drivers);

            return BadRequest(drivers);
        }

        [HttpGet("GetUnapprovedDrivers")]
        public async Task<IActionResult> GetUnapprovedDrivers( )
        {
            var drivers = await _driverService.GetUnapprovedDrivers();
            if (drivers.Success == true) return Ok(drivers);

            return BadRequest(drivers);
        }

        [HttpGet("GetDriverWithVehicle")]
        public async Task<IActionResult> GetDriverWithVehicle([FromRoute]string email )
        {
            var driver = await _driverService.GetDriverWithVehicle(email);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetDriverById/{id}")]
        public async Task<IActionResult> GetDriverById([FromRoute] int id )
        {
            var driver = await _driverService.GetDriverByid(id);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetDriverByEmail")]
        public async Task<IActionResult> GetDriverEmail(string email )
        {
            var driver = await _driverService.GetDriverByEmail(email);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetUnapprovedDriversCount")]
        public async Task<IActionResult> GetUnapprovedDriversCount()
        {
            var count = await _driverService.GetUnapprovedDriversCount();
            return Ok(count);
        }

    }
}
