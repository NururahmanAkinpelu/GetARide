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
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationContext _context;
        public BookingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Booking> CancelBooking(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == id, cancellationToken);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync(cancellationToken);
            return booking;
        }

        public async Task<Booking> CreateBooking(Booking booking, CancellationToken cancellationtoken)
        {
            cancellationtoken.ThrowIfCancellationRequested();
            await _context.Bookings.AddAsync(booking, cancellationtoken);
            await _context.SaveChangesAsync(cancellationtoken);
            return booking;
        }

        public async  Task<ICollection<Booking>> GetAllDriverBookings(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Passenger).Where(d => d.DriverId == id).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetAllPassengerBookings(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Where(d => d.PassengerId == id).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Passenger).Include(b => b.Driver).Where(b => b.CreatedOn == dateTime).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetBookingsByDriverEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Where(b => b.Driver.Email == email).ToListAsync();
            return bookings;
        }

        public async  Task<Booking> GetBookingByReferenceNumber(string referenceNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (referenceNumber == null)
            {
                throw new ArgumentNullException();
            }
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.ReferenceNumber == referenceNumber, cancellationToken);
            return booking;
        }

        public async Task<ICollection<Booking>> GetBookingsByPassengerEmail(string eamil, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Passenger).Where(b => b.Passenger.Email == eamil).ToListAsync();
            return bookings;
        }

        public async Task<Booking> UpdateBooking(Booking booking, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync(cancellationToken);
            return booking;
        }

        public async Task<ICollection<Booking>> GetAllAcceptedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == BookingStatus.Accepted).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetAllRejectedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == BookingStatus.Rejected).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetAllCancelledBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == BookingStatus.Canceled).ToListAsync();
            return bookings; 
        }

        public async Task<ICollection<Booking>> GetAcceptedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
                Where(b => b.Status == BookingStatus.Accepted && b.LastModifiedOn == dateTime).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
               Where(b => b.Status == BookingStatus.Rejected && b.LastModifiedOn == dateTime).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetCancelledBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _context.Bookings.Include(b => b.Driver).Include(b => b.Passenger).
               Where(b => b.Status == BookingStatus.Canceled && b.LastModifiedOn == dateTime).ToListAsync();
            return bookings;
        }
    }
}
