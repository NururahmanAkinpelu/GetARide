using GetARide.DTO;
using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface IBookingService
    {
        public Task<BaseResponse> CreateBooking(int userId, CancellationToken cancellationToken);
        public Task<BaseResponse> CancelBooking(int id, CancellationToken cancellationToken);
        public Task<BaseResponse> AcceptBooking(int driverId, int id, CancellationToken cancellationToken);
        public Task<BookingResponseModel> GetBookingByReferenceNumber(string referenceNumber, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetBookingsByDriverEmail(string email, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetBookingsByPassengerEmail(string email, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetBookingByStatus(BookingStatus status, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetAllDriverBookings(int id, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetAllPassengerBookings(int id, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetAllAcceptedBookings(CancellationToken cancellationToken);
        //public Task<BookingsResponseModel> GetAllRejectedBookings(CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetAllCancelledBookings(CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetAcceptedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
        //public Task<BookingsResponseModel> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetCancelledBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetAllCreatedBookingsByLocation(string location, CancellationToken cancellationToken);
    }
}
