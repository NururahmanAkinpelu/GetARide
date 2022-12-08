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
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost("CreateTrip")]
        public async Task<IActionResult> CreateTrip([FromForm]TripRequestModel model )
        {
            var trip = await _tripService.CreateTrip(model);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpPost("MakeReservation")]
        public async Task<IActionResult> MakeReservation([FromForm] TripRequestModel model)
        {
            var trip = await _tripService.MakeReservation(model);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpPut("StartTrip/{tripId}")]
        public async Task<IActionResult> StartTrip(int tripId)
        {
            var trip = await _tripService.StartTrip(tripId);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpPut("EndTrip/{id}")]
        public async Task<IActionResult> EndTrip([FromBody]UpdateTripRequestModel model, [FromRoute]int id)
        {
            var trip = await _tripService.EndTrip(model, id);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpGet("GetOngoingTrips")]
        public async Task<IActionResult> GetOngoingTrips()
        {
            var trip = await _tripService.GetOngoingTrips();
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpGet("GetEndedTrips")]
        public async Task<IActionResult> GetEndedTrips()
        {
            var trip = await _tripService.GetEndedTrips();
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpGet("GetOngoingTripsCount")]
        public async Task<IActionResult> GetOngoingTripsCount()
        {
            var count = await _tripService.GetOngoingTripsCount();
            return Ok(count);
        }
    }
}
