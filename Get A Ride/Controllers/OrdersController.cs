using GetARide.DTO;
using GetARide.Entities;
using GetARide.Interface.IService;
using Microsoft.AspNetCore.Authorization;
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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("MakeOrder/{tripId}/{userId}")]
        public async Task<IActionResult> MakeOrder([FromRoute]int tripId,[FromRoute]int userId)
        {  
            var booking = await _orderService.MakeOrder(tripId, userId);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpPut("CancelOrder/{id}")]
        public async Task<IActionResult> CancelOrder([FromRoute]int id)
        {
            ;
            var booking = await _orderService.CancelOrder(id);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpPost("MakeReservation/{tripId}/{userId}")]
        public async Task<IActionResult> MakeReservation([FromRoute] int tripId, [FromRoute] int userId)
        {
            var booking = await _orderService.MakeReservation(tripId, userId);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        //[Authorize Role = "Driver"]
        [HttpPut("AcceptOrder/{bookingId}/{driverId}")]
        public async Task<IActionResult> AcceptOrder([FromRoute] int bookingId,[FromRoute] int driverId)
        {
            var booking = await _orderService.AcceptOrder(bookingId, driverId);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetOrderByReferenceNumber")]
        public async Task<IActionResult> GetOrderByReferenceNumber([FromRoute] string referenceNumber)
        {
            var booking = await _orderService.GetOrderByReferenceNumber(referenceNumber);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetOrdersByDriverEmail")]
        public async Task<IActionResult> GetOrdersByDriverEmail(string email)
        {
            var booking = await _orderService.GetOrdersByDriverEmail(email);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetOrdersByPassengerEmail")]
        public async Task<IActionResult> GetOrdersByPassengerEmail(string email )
        {
            var booking = await _orderService.GetOrdersByPassengerEmail(email);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetOrdersByDate")]
        public async Task<IActionResult> GetOrdersByDate(DateTime dateTime)
        {
            var booking = await _orderService.GetOrdersByDate(dateTime);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllDriverOrders/{id}")]
        public async Task<IActionResult> GetAllDriverOrders([FromRoute]int id)
        {
         
            var booking = await _orderService.GetAllDriverOrders(id);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllPassengerOrders/{id}")]
        public async Task<IActionResult> GetAllPassengerOrders([FromRoute] int id)
        {

            var booking = await _orderService.GetAllPassengerOrders(id);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllAcceptedOrders")]
        public async Task<IActionResult> GetAllAcceptedOrders()
        {
            var booking = await _orderService.GetAllAcceptedOrders();
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllCancelledOrders")]
        public async Task<IActionResult> GetAllCancelledOrders()
        {
            var booking = await _orderService.GetAllCancelledOrders();
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAcceptedOrdersByDate")]
        public async Task<IActionResult> GetAcceptedOrdersByDate(DateTime dateTime)
        {
            var booking = await _orderService.GetAcceptedOrdersByDate(dateTime);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetCancelledOrdersByDate")]
        public async Task<IActionResult> GetCancelledOrdersByDate(DateTime dateTime )
        {
            var booking = await _orderService.GetCancelledOrdersByDate(dateTime);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllCreatedOrderByLocation/{location}")]
        public async Task<IActionResult> GetAllCreatedOrderByLocation([FromRoute]string location)
        {
            var booking = await _orderService.GetAllCreatedOrderByLocation(location);
            if (booking.Success == true) return Ok(booking);

            return BadRequest(booking);
        }

        [HttpGet("GetAllCreatedOrdersByLocationCount/{location}")]
        public async Task<IActionResult> GetAllCreatedOrdersByLocationCount([FromRoute] string location)
        {
            var booking = await _orderService.GetAllCreatedOrdersByLocationCount(location);
            return Ok(booking);
        }
    }
}
