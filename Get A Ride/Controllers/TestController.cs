using GetARide.DTO;
using GetARide.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public TestController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpPost("RegisterVehicle")]
        public async Task<IActionResult> RegisterVehicle([FromForm] VehicleRequestModel model)
        {
            /*            var files = HttpContext.Request.Form;

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
                                model.Document = documents;
                            }
                        }*/
            //var vehicle = await _vehicleService.RegisterVehicle(model, model.DriverId);
            //if (vehicle.Success == true) return Ok(vehicle);

            return BadRequest();
        }
    }
}
