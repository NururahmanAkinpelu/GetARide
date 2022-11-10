using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IBookingRepository
    {
        public Task<Booking> CreateBooking(Booking booking, CancellationToken cancellationtoken);
        public Task<Booking> UpdateBooking(Booking booking, CancellationToken cancellationToken);
        public Task<Booking> CancelBooking(int id, CancellationToken cancellationToken);
        public Task<Booking> GetBooking(int id, CancellationToken cancellationToken);
        public Task<Booking> GetBookingByReferenceNumber(string referenceNumber, CancellationToken cancellationToken);
        public Task<ICollection<Booking>> GetBookingsByDriverEmail(string email, CancellationToken cancellationToken);
        public Task<ICollection<Booking>> GetBookingsByPassengerEmail(string email, CancellationToken cancellationToken);

        public Task<ICollection<Booking>> GetBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
        public Task<ICollection<Booking>> GetAllDriverBookings(int id, CancellationToken cancellationToken);
        public Task<ICollection<Booking>> GetAllPassengerBookings(int id, CancellationToken cancellationToken);
        public Task<ICollection<Booking>> GetAllAcceptedBookings(CancellationToken cancellationToken);
        public Task<ICollection<Booking>> GetAllCreatedBookingsByLocation(string location, CancellationToken cancellationtoken);
        /*public Task<ICollection<Booking>> GetAllRejectedBookings(CancellationToken cancellationToken);*/
        public Task<ICollection<Booking>> GetAllCancelledBookings(CancellationToken cancellationToken);
        public Task<ICollection<Booking>> GetAcceptedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
       /* public Task<ICollection<Booking>> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);*/
        public Task<ICollection<Booking>> GetCancelledBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
      
    }
}
