using GetARide.Context;
using GetARide.Entities;
using GetARide.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;
        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Order> CancelBooking(int id )
        {
            
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Order> CreateBooking(Order booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async  Task<ICollection<Order>> GetAllDriverBookings(int id )
        {
            var bookings = await _context.Bookings.Include(b => b.Passenger).Where(d => d.DriverId == id).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Order>> GetAllPassengerBookings(int id )
        {
            var bookings = await _context.Bookings.Include(b => b.Driver).Where(d => d.PassengerId == id).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Order>> GetBookingsByDate(DateTime dateTime )
        {
            var bookings = await _context.Bookings.Include(b => b.Passenger).Include(b => b.Driver).Where(b => b.CreatedOn == dateTime).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Order>> GetBookingsByDriverEmail(string email )
        {
            var bookings = await _context.Bookings.Include(b => b.Driver).Where(b => b.Driver.Email == email).ToListAsync();
            return bookings;
        }

        public async  Task<Order> GetBookingByReferenceNumber(string referenceNumber)
        {
            if (referenceNumber == null)
            {
                throw new ArgumentNullException();
            }
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.ReferenceNumber == referenceNumber);
            return booking;
        }

        public async Task<ICollection<Order>> GetBookingsByPassengerEmail(string eamil)
        {
            var bookings = await _context.Bookings.Include(b => b.Passenger).Where(b => b.Passenger.Email == eamil).ToListAsync();
            return bookings;
        }

        public async Task<Order> UpdateBooking(Order booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<ICollection<Order>> GetAllAcceptedBookings()
        {
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == OrderStatus.Accepted).ToListAsync();
            return bookings;
        }

        /*public async Task<ICollection<Order>> GetAllRejectedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == OrderStatus.Rejected).ToListAsync();
            return bookings;
        }*/

        public async Task<ICollection<Order>> GetAllCancelledBookings()
        {
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == OrderStatus.Canceled).ToListAsync();
            return bookings; 
        }

        public async Task<ICollection<Order>> GetAcceptedBookingsByDate(DateTime dateTime)
        {
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == OrderStatus.Accepted && b.LastModifiedOn == dateTime).ToListAsync();
            return bookings;
        }

       /* public async Task<ICollection<Order>> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
               Where(b => b.Status == OrderStatus.Rejected && b.LastModifiedOn == dateTime).ToListAsync();
            return bookings;
        }*/

        public async Task<ICollection<Order>> GetCancelledBookingsByDate(DateTime dateTime)
        {
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
               Where(b => b.Status == OrderStatus.Canceled && b.LastModifiedOn == dateTime).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Order>> GetAllCreatedBookingsByLocation(string location)
        {
            var bookings = await _context.Bookings.Include(b => b.Trip).Where(b => b.Status == OrderStatus.Sent).Where(b => b.Trip.Status == TripStatus.NotStarted ).Where(b => b.Trip.PickUpLocation == location).ToListAsync();
            return bookings;
        }

        public async Task<Order> GetBooking(int id )
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == id);
            return booking;
        }

        public async Task<Order> GetOrderByTripId(int tripId)
        {
            var order = await _context.Bookings.SingleOrDefaultAsync(o => o.TripId == tripId);
            return order;
        }
    }
}
