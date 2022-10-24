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
        public async Task<IActionResult> RegisterDriver([FromForm] DriverRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var files = HttpContext.Request.Form;
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
            }


            var driver = await _driverService.RegisterDriver(model, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpPut("UpdateDriver")]
        public async Task<IActionResult> UpdateDriver ([FromForm] UpdateDriverRequestModel model, [FromRoute]string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
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
            var driver = await _driverService.UpdateDriver(model,email, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> GetAlldrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverService.GetAllDrivers(cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpPost("ApproveDriver")]
        public async Task<IActionResult> ApprovedDriver([FromRoute]string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverService.ApproveDriver(email, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpPost("ActivateDriver")]
        public async Task<IActionResult> ActivateDriver([FromRoute] string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverService.ActivateDriver(email, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpDelete("Deactivatedriver")]
        public async Task<IActionResult> DeactivateDriver([FromRoute] string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverService.DeactivateDriver(email, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetApprovedDrivers")]
        public async Task<IActionResult> GetApprovedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverService.GetApprovedDrivers(cancellationToken);
            if (drivers.Success == true) return Ok(drivers);

            return BadRequest(drivers);
        }

        [HttpGet("GetUnapprovedDrivers")]
        public async Task<IActionResult> GetUnapprovedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverService.GetUnapprovedDrivers(cancellationToken);
            if (drivers.Success == true) return Ok(drivers);

            return BadRequest(drivers);
        }

        [HttpGet("GetDriverWithVehicle")]
        public async Task<IActionResult> GetDriverWithVehicle([FromRoute]string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverService.GetDriverWithVehicle(email, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetDriverById/{id}")]
        public async Task<IActionResult> GetDriverById([FromRoute] int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverService.GetDriverByid(id, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

        [HttpGet("GetDriverByEmail")]
        public async Task<IActionResult> GetDriverEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverService.GetDriverByEmail(email, cancellationToken);
            if (driver.Success == true) return Ok(driver);

            return BadRequest(driver);
        }

    }
}
