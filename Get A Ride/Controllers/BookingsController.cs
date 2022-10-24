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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromForm]BookingRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.CreateBooking(model, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpPost("CancelBooking")]
        public async Task<IActionResult> CancelBooking([FromRoute]string referenceNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.CancelBooking(referenceNumber, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpPost("AcceptBooking")]
        public async Task<IActionResult> AcceptBooking([FromRoute]string referenceNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.AcceptBooking(referenceNumber, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpPost("RejectBooking")]
        public async Task<IActionResult> RejectBooking([FromRoute] string referenceNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.RejectBooking(referenceNumber, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetBookingByReferenceNumber")]
        public async Task<IActionResult> GetBookingByReferenceNumber([FromRoute] string referenceNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetBookingByReferenceNumber(referenceNumber, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetBookingsByDriverEmail")]
        public async Task<IActionResult> GetBookingsByDriverEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetBookingsByDriverEmail(email, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetBookingsByPassengerEmail")]
        public async Task<IActionResult> GetBookingsByPassengerEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetBookingsByPassengerEmail(email, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetBookingsByDate")]
        public async Task<IActionResult> GetBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetBookingsByDate(dateTime, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllDriverBookings/{id}")]
        public async Task<IActionResult> GetAllDriverBookings([FromRoute]int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetAllDriverBookings(id, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllPassengerBookings/{id}")]
        public async Task<IActionResult> GetAllPassengerBookings([FromRoute] int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetAllPassengerBookings(id, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllAcceptedBookings")]
        public async Task<IActionResult> GetAllAcceptedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetAllAcceptedBookings(cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllRejectedBookings")]
        public async Task<IActionResult> GetAllRejectedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetAllRejectedBookings(cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllCancelledBookings")]
        public async Task<IActionResult> GetAllCancelledBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetAllCancelledBookings(cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAcceptedBookingsByDate")]
        public async Task<IActionResult> GetAcceptedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetAcceptedBookingsByDate(dateTime, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetRejectedBookingsByDate")]
        public async Task<IActionResult> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetRejectedBookingsByDate(dateTime, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetCancelledBookingsByDate")]
        public async Task<IActionResult> GetCancelledBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingService.GetCancelledBookingsByDate(dateTime, cancellationToken);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }
    }
}
