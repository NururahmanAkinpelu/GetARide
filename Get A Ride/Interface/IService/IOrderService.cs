using GetARide.DTO;
using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface IOrderService
    {
        public Task<BookingResponseModel> MakeOrder(int tripId, int userId );
        public Task<BookingResponseModel> MakeReservation(int tripId, int userId);
        public Task<BaseResponse> CancelOrder(int id);
        public Task<BaseResponse> AcceptOrder(int driverId, int id );
        public Task<BookingResponseModel> GetOrderByReferenceNumber(string referenceNumber );
        public Task<BookingsResponseModel> GetOrdersByDriverEmail(string email );
        public Task<BookingsResponseModel> GetOrdersByPassengerEmail(string email );
        public Task<BookingsResponseModel> GetOrdersByDate(DateTime dateTime );
        public Task<BookingsResponseModel> GetBookingByStatus(OrderStatus status );
        public Task<BookingsResponseModel> GetAllDriverOrders(int id );
        public Task<BookingsResponseModel> GetAllPassengerOrders(int id );
        public Task<BookingsResponseModel> GetAllAcceptedOrders( );
        //public Task<BookingsResponseModel> GetAllRejectedBookings(CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetAllCancelledOrders( );
        public Task<BookingsResponseModel> GetAcceptedOrdersByDate(DateTime dateTime );
        //public Task<BookingsResponseModel> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
        public Task<BookingsResponseModel> GetCancelledOrdersByDate(DateTime dateTime);
        public Task<BookingsResponseModel> GetAllCreatedOrderByLocation(string location );
        public Task<int> GetAllCreatedOrdersByLocationCount(string location);
    }
}
