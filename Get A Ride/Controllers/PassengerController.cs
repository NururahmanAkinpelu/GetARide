using GetARide.DTO;
using GetARide.Interface.IService;
using Microsoft.AspNetCore.Hosting;
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
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PassengerController(IPassengerService passengerService, IWebHostEnvironment webHostEnvironment)
        {
            _passengerService = passengerService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("RegisterPassenger")]
        public async Task<IActionResult> RegisterPassenger([FromForm]PassengerRequestModel model)
        {
            var passenger = await _passengerService.RegisterPassnger(model);
            if (passenger.Success == true) return Ok(passenger);

            return BadRequest(passenger);
        }

        [HttpPut("UpdatePassenger/{id}")]
        public async Task<IActionResult> UpdatePassenger([FromForm]UpdateAPassengerRequestModel model,[FromRoute]int id)
        {
            var passenger = await _passengerService.UpdatePassenger(model, id);
            if (passenger.Success == true) return Ok(passenger);

            return BadRequest(model);
        }

        [HttpGet("GetPassengerById/{id}")]
        public async Task<IActionResult> GetPassengerById([FromRoute]int id)
        {
            var passenger = await _passengerService.GetPassengerById(id);
            if (passenger.Success == true) return Ok(passenger);

            return BadRequest(passenger);
        }

        [HttpGet("GetPassengerByEmail")]
        public async Task<IActionResult> GetPassengerByEmail(string email)
        {
            var passenger = await _passengerService.GetPassengerByEmail(email);
            if (passenger.Success == true) return Ok(passenger);

            return BadRequest(passenger);
        }

        [HttpGet("GetAllPassengers")]
        public async Task<IActionResult> GetAllPassenger()
        {
            var passengers = await _passengerService.GetAllPassengers();
            if (passengers.Success == true) return Ok(passengers);

            return BadRequest(passengers);
        }

        [HttpGet("GetActivePassengers")]
        public async Task<IActionResult> GetActivatedPassengers()
        {
            var passengers = await _passengerService.GetActivePassengers();
            if (passengers.Success == true) return Ok(passengers);

            return BadRequest(passengers);
        }

        [HttpGet("GetDeactivatedPassengers")]
        public async Task<IActionResult> GetDeactivatedPassengers()
        {
            var passengers = await _passengerService.GetDeactivatedPassengers();
            if (passengers.Success == true) return Ok(passengers);

            return BadRequest(passengers);
        }

        [HttpPut("ActivatePassenger/{id}")]
        public async Task<IActionResult> ActivatePassenger([FromRoute] int id)
        {
            var passenger = await _passengerService.ActivatePassenger(id);
            if (passenger.Success == true) return Ok(passenger);

            return BadRequest(passenger);
        }

        [HttpPut("DeactivatePassenger/{id}")]
        public async Task<IActionResult> DeactivatePassenger([FromRoute] int id)
        {
            var passenger = await _passengerService.DeactivatePassenger(id);
            if (passenger.Success == true) return Ok(passenger);

            return BadRequest(passenger);
        }
    }
}
