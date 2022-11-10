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
        public async Task<IActionResult> CreateTrip([FromForm]TripRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _tripService.CreateTrip(model, cancellationToken);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpPost("StartTrip/{tripId}")]
        public async Task<IActionResult> StartTrip(int tripId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _tripService.StartTrip(tripId, cancellationToken);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpPost("EndTrip/{id}")]
        public async Task<IActionResult> EndTrip([FromRoute]int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _tripService.EndTrip(id, cancellationToken);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpGet("GetOngoingTrips")]
        public async Task<IActionResult> GetOngoingTrips(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _tripService.GetOngoingTrips(cancellationToken);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }

        [HttpGet("GetEndedTrips")]
        public async Task<IActionResult> GetEndedTrips(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _tripService.GetEndedTrips(cancellationToken);
            if (trip.Success == true) return Ok(trip);

            return BadRequest(trip);
        }
    }
}
