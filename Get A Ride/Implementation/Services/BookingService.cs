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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly ITripRepository _tripRepository;
        private readonly IUserRepository _userRepository;


        public BookingService(IBookingRepository bookingRepository, IDriverRepository driverRepository, IPassengerRepository passengerRepository, ITripRepository tripRepository, IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _driverRepository = driverRepository;
            _passengerRepository = passengerRepository;
            _tripRepository = tripRepository;
            _userRepository = userRepository;
        }
        public async Task<BaseResponse> AcceptBooking(int driverId, int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingRepository.GetBooking(id, cancellationToken);
            if (booking == null)
            {
                return new BaseResponse
                {
                    Message = "Booking not found",
                    Success = false
                };
            }
            var driver = await _driverRepository.GetDriverById(driverId, cancellationToken);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "Driver not found",
                    Success = false
                };
            }

            if (booking.Status == BookingStatus.Accepted)
            {
                return new BaseResponse
                {
                    Message = "Booking already accepted",
                    Success = false
                };
            }
            booking.DriverId = driverId;
            booking.Status = BookingStatus.Accepted;
            driver.IsAvailable = false;
            await _bookingRepository.UpdateBooking(booking, cancellationToken);
            return new BaseResponse
            {
                Message = "Booking Accepted",
                Success = true
            };
        }

        public async Task<BaseResponse> CreateBooking(int id, CancellationToken cancellationToken)
        {
           
            cancellationToken.ThrowIfCancellationRequested();
            var passenger = await _userRepository.GetUserAsync(id, cancellationToken);
            /* if (passenger == null)
             {
                 return new BaseResponse
                 {
                     Message = "Passenger not found",
                     Success = false
                 };
             }*/

            /*var driver = await _driverRepository.GetDriverById(model.DriverId, cancellationToken);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "Driver not found",
                    Success = false
                };
            }
            var booking = await _bookingRepository.GetBookingByReferenceNumber(model.ReferenceNumber, cancellationToken);*/
            var generateReferencenumber = $"Ref{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
            
            var newBooking = new Booking
            {
                ReferenceNumber = generateReferencenumber,
                Status = BookingStatus.Sent,
                PassengerId = passenger.Id,
                IsDeleted = false,
                CreatedBy = passenger.Id,
                LastModifiedBy = passenger.Id,
            };
           


            await _bookingRepository.CreateBooking(newBooking, cancellationToken);
            return new BaseResponse
            {
                Message = "Succesfully sent",
                Success = true
            };
        }

        public async Task<BookingsResponseModel> GetAllAcceptedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetAllAcceptedBookings(cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "No bookings accepted",
                    Success = false
                };
            }

            return new BookingsResponseModel
            {
                Message = "List of accepted bookings",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id
                }).ToList()
            };
        }

        public async Task<BookingsResponseModel> GetAllCancelledBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetAllCancelledBookings(cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "No booking is cancelled",
                    Success = false
                };
            }

            return new BookingsResponseModel
            {
                Message = "List of cancelled bookings",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id
                }).ToList()
            };
        }

        public async Task<BookingsResponseModel> GetAllDriverBookings(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetAllDriverBookings(id, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "This driver has no booking",
                    Success = false
                };
            }
            return new BookingsResponseModel
            {
                Message = "List of Driver's bookings",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    TripId = b.Trip.Id
                }).ToList()
            };
        }

        public async Task<BookingsResponseModel> GetAllPassengerBookings(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetAllPassengerBookings(id, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "This Passenger did not make any booking",
                    Success = false
                };
            }
            var bookingsDto = bookings.Select(b => new BookingDTO
            {
                ReferenceNumber = b.ReferenceNumber,
                Status = b.Status,
                DriverId = b.DriverId,
                TripId = b.Trip.Id
            }).ToList();
            return new BookingsResponseModel
            {
                Message = "List of Passenger's bookings",
                Success = true,
                BookingDtos = bookingsDto
            };
        }

        /*public async Task<BookingsResponseModel> GetAllRejectedBookings(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetAllRejectedBookings(cancellationToken);
            if (bookings == null)
            {
                return new BookingsResponseModel
                {
                    Message = "No booking is rejected",
                    Success = false
                };
            }

            return new BookingsResponseModel
            {
                Message = "List of rejected bookings",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id
                }).ToList()
            };
        }*/
       
        public async Task<BookingsResponseModel> GetBookingsByDriverEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetBookingsByDriverEmail(email, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "This driver has no booking",
                    Success = false
                };
            }
            return new BookingsResponseModel
            {
                Message = "List of Driver's bookings",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    TripId = b.Trip.Id

                }).ToList()
            };
        }

        public async Task<BookingResponseModel> GetBookingByReferenceNumber(string refernceNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingRepository.GetBookingByReferenceNumber(refernceNumber, cancellationToken);
            if (booking == null)
            {
                return new BookingResponseModel
                {
                    Message = "Booking deos not exists",
                    Success = false
                };
            }
            return new BookingResponseModel
            {
                BookingDto = new BookingDTO
                {
                    ReferenceNumber = booking.ReferenceNumber,
                    Status = booking.Status,
                    PassengerId = booking.PassengerId,
                    DriverId = booking.DriverId,
                    TripId = booking.Trip.Id
                },
                Message = "Booking gotten ",
                Success = true
            };
        }

        public async Task<BookingsResponseModel> GetBookingsByPassengerEmail(string email, CancellationToken cancellationToken)
        {
            var bookings = await _bookingRepository.GetBookingsByPassengerEmail(email, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "This Passenger did not make any booking",
                    Success = false
                };
            }
            return new BookingsResponseModel
            {
                Message = "List of Passenger's bookings",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id

                }).ToList()
            };
        }

        public async Task<BookingsResponseModel> GetBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetBookingsByDate(dateTime, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "No booking on this date",
                    Success = false
                };
            }

            return new BookingsResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id

                }).ToList()
            };
        }

        public async Task<BaseResponse> CancelBooking(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var booking = await _bookingRepository.GetBooking(id, cancellationToken);
            if (booking == null)
            {
                return new BaseResponse
                {
                    Message = "Not found",
                    Success = false
                };
            }
            if (booking != null && booking.Status == BookingStatus.Canceled)
            {
                return new BaseResponse
                {
                    Message = "Booking already cancelled",
                    Success = false
                };
            }
            booking.Status = BookingStatus.Canceled;
            booking.Driver.IsAvailable = true;
            await _bookingRepository.UpdateBooking(booking, cancellationToken);
            return new BaseResponse
            {
                Message = "Booking cancelled",
                Success = false
            };
        }

        public async Task<BookingsResponseModel> GetAcceptedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetAcceptedBookingsByDate(dateTime, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "No accepted booking on this date",
                    Success = false
                };
            }

            return new BookingsResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id

                }).ToList()
            };
        }

       /* public async Task<BookingsResponseModel> GetRejectedBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetRejectedBookingsByDate(dateTime, cancellationToken);
            if (bookings == null)
            {
                return new BookingsResponseModel
                {
                    Message = "No rejected booking on this date",
                    Success = false
                };
            }

            return new BookingsResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                    TripId = b.Trip.Id

                }).ToList()
            };
        }*/

        public async Task<BookingsResponseModel> GetCancelledBookingsByDate(DateTime dateTime, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetCancelledBookingsByDate(dateTime, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "No cancelled booking on this date",
                    Success = false
                };
            }

            return new BookingsResponseModel
            {
                Message = $"List of bookings on{dateTime}",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    ReferenceNumber = b.ReferenceNumber,
                    Status = b.Status,
                    PassengerId = b.PassengerId,
                    DriverId = b.DriverId,
                }).ToList()
            };
        }

        Task<BookingsResponseModel> IBookingService.GetBookingByStatus(BookingStatus status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingsResponseModel> GetAllCreatedBookingsByLocation(string driversLocation, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var bookings = await _bookingRepository.GetAllCreatedBookingsByLocation(driversLocation, cancellationToken);
            if (bookings.Count == 0)
            {
                return new BookingsResponseModel
                {
                    Message = "No bookins",
                    Success = false
                };
            }
           
            return new BookingsResponseModel
            {
                Message = "List of Bookings",
                Success = true,
                BookingDtos = bookings.Select(b => new BookingDTO
                {
                    PassengerId = b.PassengerId,
                    StartLocation = b.Trip.PickUpLocation,
                    EndLocation = b.Trip.DropLocation,
                }).ToList()
            };
            throw new NotImplementedException();
        }
    }
}
