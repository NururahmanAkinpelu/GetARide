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
        public Task<OrderResponseModel> MakeOrder(int tripId, int userId );
        public Task<OrderResponseModel> MakeReservation(int tripId, int userId);
        public Task<BaseResponse> CancelOrder(int id);
        public Task<BaseResponse> AcceptOrder(int driverId, int id );
        public Task<OrderResponseModel> GetOrderByReferenceNumber(string referenceNumber );
        public Task<OrdersResponseModel> GetOrdersByDriverEmail(string email );
        public Task<OrdersResponseModel> GetOrdersByPassengerEmail(string email );
        public Task<OrdersResponseModel> GetOrdersByDate(DateTime dateTime );
        public Task<OrdersResponseModel> GetBookingByStatus(OrderStatus status );
        public Task<OrdersResponseModel> GetAllDriverOrders(int id );
        public Task<OrdersResponseModel> GetAllPassengerOrders(int id );
        public Task<OrdersResponseModel> GetAllAcceptedOrders( );
        //public Task<OrdersResponseModel> GetAllRejectedBookings(CancellationToken cancellationToken);
        public Task<OrdersResponseModel> GetAllCancelledOrders( );
        public Task<OrdersResponseModel> GetAcceptedOrdersByDate(DateTime dateTime );
        //public Task<OrdersResponseModel> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken);
        public Task<OrdersResponseModel> GetCancelledOrdersByDate(DateTime dateTime);
        public Task<OrdersResponseModel> GetAllCreatedOrderByLocation(string location );
        public Task<int> GetAllCreatedOrdersByLocationCount(string location);
        public Task<OrderResponseModel> CalculateOrderPrice(int orderId);
    }
}
