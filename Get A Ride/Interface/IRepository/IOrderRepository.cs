using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IOrderRepository
    {
        public Task<Order> CreateBooking(Order booking );
        public Task<Order> UpdateBooking(Order booking );
        public Task<Order> CancelBooking(int id);
        public Task<Order> GetBooking(int id );
        public Task<Order> GetOrderByTripId(int tripId);
        public Task<Order> GetBookingByReferenceNumber(string referenceNumber );
        public Task<ICollection<Order>> GetBookingsByDriverEmail(string email );
        public Task<ICollection<Order>> GetBookingsByPassengerEmail(string email);
        public Task<ICollection<Order>> GetBookingsByDate(DateTime dateTime );
        public Task<ICollection<Order>> GetAllDriverBookings(int id );
        public Task<ICollection<Order>> GetAllPassengerBookings(int id );
        public Task<ICollection<Order>> GetAllAcceptedBookings( );
        public Task<ICollection<Order>> GetAllCreatedBookingsByLocation(string location );
        public Task<ICollection<Order>> GetAllCancelledBookings();
        public Task<ICollection<Order>> GetAcceptedBookingsByDate(DateTime dateTime);
        public Task<ICollection<Order>> GetCancelledBookingsByDate(DateTime dateTime);
      
    }
}
