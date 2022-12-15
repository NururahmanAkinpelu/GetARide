using GetARide.DTO;
using GetARide.Interface.IRepository;
using GetARide.Interface.IService;
using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using GetARide.Entities.Identity;

namespace GetARide.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly ITripRepository _tripRepository;
        private readonly IUserRepository _userRepository;


        public OrderService(IOrderRepository orderRepository, IDriverRepository driverRepository, IPassengerRepository passengerRepository, ITripRepository tripRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _driverRepository = driverRepository;
            _passengerRepository = passengerRepository;
            _tripRepository = tripRepository;
            _userRepository = userRepository;
        }
        public async Task<BaseResponse> AcceptOrder(int bookingId, int driverId)
        {
            var booking = await _orderRepository.GetBooking(bookingId);
            if (booking == null)
            {
                return new BaseResponse
                {
                    Message = "Order not found",
                    Success = false
                };
            }
            var driver = await _driverRepository.GetDriverByUserId(driverId);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "Driver not found",
                    Success = false
                };
            }

            if (booking.Status == OrderStatus.Accepted)
            {
                return new BaseResponse
                {
                    Message = "Order already accepted",
                    Success = false
                };
            }
            booking.DriverId = driver.Id;
            booking.Status = OrderStatus.Accepted;
            driver.IsAvailable = false;
            await _orderRepository.UpdateBooking(booking);
            return new BaseResponse
            {
                Message = "Order Accepted",
                Success = true
            };
        }

        public async Task<OrderResponseModel> MakeOrder(int tripId, int passengerId)
        {
            var order = await _orderRepository.GetOrderByTripId(tripId);
            if (order!= null)
            {
                return new OrderResponseModel
                {
                    Message = "You order has been sent, a driver will soon accept your requst",
                    Success = false
                };
            }
            var passenger = await _passengerRepository.GetPassengerByUserId(passengerId);
            var trip = await _tripRepository.GetTrip(tripId);
            //var booking = await _orderRepository.GetOrderByReferenceNumber(model.ReferenceNumber, cancellationToken);*/
            var generateReferencenumber = $"Ref{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";

            
            var newBooking = new Order
            {
                ReferenceNumber = generateReferencenumber,
                Status = OrderStatus.Sent,
                PassengerId = passenger.Id,
                IsDeleted = false,
                CreatedBy = passenger.Id,
                LastModifiedBy = passenger.Id,
                TripId = trip.Id,
                Type = OrderType.Immediate          
            };
            newBooking.Passenger = passenger;
            newBooking.IsReady = true;
            var booking = await _orderRepository.CreateBooking(newBooking);

            var bookingDto = new OrderDTO
            {
                TripId = booking.TripId,                
                Id = booking.Id,
                ReferenceNumber = newBooking.ReferenceNumber,
                Status = newBooking.Status,
                PassengerId = newBooking.PassengerId,
                Type = newBooking.Trip.Type.ToString()
            };
            
            return new OrderResponseModel
            {
                Message = "Succesfully sent",
                Success = true,
                OrderDto = bookingDto                
            };
        }

        public async Task<OrderResponseModel> MakeReservation(int tripId, int userId)
        {
            var order = await _orderRepository.GetOrderByTripId(tripId);
            if (order != null)
            {
                return new OrderResponseModel
                {
                    Message = "You order has been sent, a driver will soon accept your requst",
                    Success = false
                };
            }
            var passenger = await _passengerRepository.GetPassengerByUserId(userId);
            var trip = await _tripRepository.GetTrip(tripId);
            //var booking = await _orderRepository.GetOrderByReferenceNumber(model.ReferenceNumber, cancellationToken);*/
            var generateReferencenumber = $"Ref{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";

            var newBooking = new Order
            {
                ReferenceNumber = generateReferencenumber,
                Status = OrderStatus.Sent,
                Type = OrderType.Reservation,
                PassengerId = passenger.Id,
                IsDeleted = false,
                CreatedBy = passenger.Id,
                LastModifiedBy = passenger.Id,
                TripId = trip.Id               
            };
            newBooking.IsReady = false;
            var booking = await _orderRepository.CreateBooking(newBooking);

            var bookingDto = new OrderDTO
            {
                TripId = booking.TripId,
                Id = booking.Id,
                ReferenceNumber = booking.ReferenceNumber,
                Status = booking.Status,
                PassengerId = booking.PassengerId,
                Type = booking.Trip.Type.ToString(),
                OrderType = booking.Type.ToString()
            };

            return new OrderResponseModel
            {
                Message = "Succesfully sent",
                Success = true,
                OrderDto = bookingDto

            };
        }  

        public async Task<OrdersResponseModel> GetAllAcceptedOrders( )
        {
            var bookings = await _orderRepository.GetAllAcceptedBookings();
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "No bookings accepted",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = "List of accepted bookings",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.TripId,
                    Type = b.Trip.Type.ToString()
                }).ToList()
            };
        }

        public async Task<OrdersResponseModel> GetAllCancelledOrders( )
        {
            var bookings = await _orderRepository.GetAllCancelledBookings();
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "No booking is cancelled",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = "List of cancelled bookings",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id,
                    Type = b.Trip.Type.ToString()
                }).ToList()
            };
        }

        public async Task<OrdersResponseModel> GetAllDriverOrders(int id )
        {
            var bookings = await _orderRepository.GetAllDriverBookings(id);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "This driver has no booking",
                    Success = false
                };
            }
            return new OrdersResponseModel
            {
                Message = "List of Driver's bookings",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    TripId = b.Trip.Id,
                    Type = b.Trip.Type.ToString()
                }).ToList()
            };
        }

        public async Task<OrdersResponseModel> GetAllPassengerOrders(int id )
        {
            var bookings = await _orderRepository.GetAllPassengerBookings(id);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "This Passenger did not make any booking",
                    Success = false
                };
            }
            var bookingsDto = bookings.Select(b => new OrderDTO
            {
                ReferenceNumber = b.ReferenceNumber,
                Status = b.Status,
                DriverId = b.DriverId,
                TripId = b.Trip.Id,
                Type = b.Trip.Type.ToString()
            }).ToList();
            return new OrdersResponseModel
            {
                Message = "List of Passenger's bookings",
                Success = true,
                OrderDto = bookingsDto
            };
        }

        /*public async Task<OrdersResponseModel> GetAllRejectedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _orderRepository.GetAllRejectedBookings(cancellationToken);
            if (bookings == null)
            {
                return new OrdersResponseModel
                {
                    Message = "No booking is rejected",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = "List of rejected bookings",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id
                }).ToList()
            };
        }*/
       
        public async Task<OrdersResponseModel> GetOrdersByDriverEmail(string email )
        {
            var bookings = await _orderRepository.GetBookingsByDriverEmail(email);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "This driver has no booking",
                    Success = false
                };
            }
            return new OrdersResponseModel
            {
                Message = "List of Driver's bookings",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    TripId = b.Trip.Id,
                    Type = b.Trip.Type.ToString()

                }).ToList()
            };
        }

        public async Task<OrderResponseModel> GetOrderByReferenceNumber(string refernceNumber)
        {
            var booking = await _orderRepository.GetBookingByReferenceNumber(refernceNumber);
            if (booking == null)
            {
                return new OrderResponseModel
                {
                    Message = "Order deos not exists",
                    Success = false
                };
            }
            return new OrderResponseModel
            {
                OrderDto = new OrderDTO
                {
                    ReferenceNumber = booking.ReferenceNumber,
                    Status = booking.Status,
                    PassengerId = booking.PassengerId,
                    DriverId = booking.DriverId,
                    TripId = booking.Trip.Id,
                    Type = booking.Trip.Type.ToString()
                },
                Message = "Order gotten ",
                Success = true
            };
        }

        public async Task<OrdersResponseModel> GetOrdersByPassengerEmail(string email)
        {
            var bookings = await _orderRepository.GetBookingsByPassengerEmail(email);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "This Passenger did not make any booking",
                    Success = false
                };
            }
            return new OrdersResponseModel
            {
                Message = "List of Passenger's bookings",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id,
                    Type = b.Trip.Type.ToString()

                }).ToList()
            };
        }

        public async Task<OrdersResponseModel> GetOrdersByDate(DateTime dateTime)
        {
            var bookings = await _orderRepository.GetBookingsByDate(dateTime);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "No booking on this date",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id,
                    Type = b.Trip.Type.ToString()

                }).ToList()
            };
        }

        public async Task<BaseResponse> CancelOrder(int id )
        {
            var booking = await _orderRepository.GetBooking(id);
            if (booking == null)
            {
                return new BaseResponse
                {
                    Message = "Not found",
                    Success = false
                };
            }
            if (booking != null && booking.Status == OrderStatus.Canceled)
            {
                return new BaseResponse
                {
                    Message = "Order already cancelled",
                    Success = false
                };
            }
            booking.Status = OrderStatus.Canceled;
            booking.Driver.IsAvailable = true;
            await _orderRepository.UpdateBooking(booking);
            return new BaseResponse
            {
                Message = "Order cancelled",
                Success = false
            };
        }

        public async Task<OrdersResponseModel> GetAcceptedOrdersByDate(DateTime dateTime )
        {
            var bookings = await _orderRepository.GetAcceptedBookingsByDate(dateTime);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "No accepted booking on this date",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id,
                    Type = b.Trip.Type.ToString()

                }).ToList()
            };
        }

       /* public async Task<OrdersResponseModel> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _orderRepository.GetRejectedBookingsByDate(dateTime, cancellationToken);
            if (bookings == null)
            {
                return new OrdersResponseModel
                {
                    Message = "No rejected booking on this date",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id

                }).ToList()
            };
        }*/

        public async Task<OrdersResponseModel> GetCancelledOrdersByDate(DateTime dateTime )
        {
            var bookings = await _orderRepository.GetCancelledBookingsByDate(dateTime);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "No cancelled booking on this date",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                }).ToList()
            };
        }

        Task<OrdersResponseModel> IOrderService.GetBookingByStatus(OrderStatus status )
        {
            throw new NotImplementedException();
        }

        public async Task<OrdersResponseModel> GetAllCreatedOrderByLocation(string driversLocation )
        {
            var bookings = await _orderRepository.GetAllCreatedBookingsByLocation(driversLocation);
            if (bookings.Count == 0)
            {
                return new OrdersResponseModel
                {
                    Message = "No bookings",
                    Success = false
                };
            }

            return new OrdersResponseModel
            {
                Message = "List of Bookings",
                Success = true,
                OrderDto = bookings.Select(b => new OrderDTO
                {
                    Id = b.Id,
                    PassengerId = b.PassengerId,
                    StartLocation = b.Trip.PickUpLocation,
                    EndLocation = b.Trip.DropLocation,
                    TripId = b.Trip.Id,
                    Type = b.Trip.Type.ToString()
                }).ToList()
            };
            throw new NotImplementedException();
        }

        public async Task<int> GetAllCreatedOrdersByLocationCount(string location)
        {
            var bookings = await _orderRepository.GetAllCreatedBookingsByLocation(location);
            int count = 0;
            foreach (var booking in bookings)
            {
                count++;
            }
            return count;
        }

        public async Task<OrderResponseModel> CalculateOrderPrice(int orderId)
        {
            var order = await _orderRepository.GetBooking(orderId);
            var trip = await _tripRepository.GetTrip(order.TripId);
            if (trip.Status == TripStatus.Ended)
            {
                order.Price = (trip.Time * 12) + (trip.Distance * 70);
            }
            await _orderRepository.UpdateBooking(order);
            return new OrderResponseModel
            {
                OrderDto = new OrderDTO
                {
                    Price = order.Price
                },
                Message = $"Your price is {order.Price} ",
                Success = true
            };
        }

        public async Task<BaseResponse> EndOrder(int orderId)
        {
            var order = await _orderRepository.GetBooking(orderId);
            order.Status = OrderStatus.Ended;
            await CalculateOrderPrice(orderId);
            await _orderRepository.UpdateBooking(order);
            return new BaseResponse
            {
                Message = $"Order ended. You are to pay{order.Price}",
                Success = true
            };
        }
    } 
}
