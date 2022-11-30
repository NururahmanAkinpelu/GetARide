using GetARide.DTO;
using GetARide.Entities;
using GetARide.Interface.IRepository;
using GetARide.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public async Task<BaseResponse> EndTrip( int id )
        {
            var trip = await _tripRepository.GetTrip(id);
            if (trip == null)
            {
                return new BaseResponse
                {
                    Message = "trip does not exist",
                    Success = false
                };
            }

            if (trip != null && trip.Status == TripStatus.Ended)
            {
                return new BaseResponse
                {
                    Message = "trip alraedy ended",
                    Success = false
                };
            }
            trip.EndTime = DateTime.UtcNow;
            trip.Status = TripStatus.Ended;
            trip.Order.Driver.IsAvailable = true;
            await _tripRepository.Updatetrip(trip);
            return new BaseResponse
            {
                Message = "trip ended succesfully",
                Success = true
            };
        }

        public async Task<TripResponseModel> CreateTrip(TripRequestModel model)
        {
            var newTrip = new Trip
            {                
                PickUpLocation = model.PickUpLocation,
                DropLocation = model.DropLocation,
                Type = TripType.Immediate
            };

            newTrip.Status = TripStatus.NotStarted;
            await _tripRepository.CreateTrip(newTrip);
            var tripDto = new TripDTO
            {
                Id = newTrip.Id,
                PickUpLocation = newTrip.PickUpLocation,
                DropLocation = newTrip.DropLocation,
                TripType = newTrip.Type,
            };

            return new TripResponseModel
            {
                Message = "Created",
                Success = true,
                TripDto = tripDto
            };
        }

        public async Task<TripResponseModel> MakeReservation(TripRequestModel model)
        {
            var newTrip = new Trip
            {
                PickUpLocation = model.PickUpLocation,
                DropLocation = model.DropLocation,
                Type = TripType.Reservation,
                Date = model.Date
            };

            newTrip.Status = TripStatus.NotStarted;
            await _tripRepository.CreateTrip(newTrip);
            var tripDto = new TripDTO
            {
                Id = newTrip.Id,
                PickUpLocation = newTrip.PickUpLocation,
                DropLocation = newTrip.DropLocation,
                Date = newTrip.Date,
                TripType = newTrip.Type
            };

            return new TripResponseModel
            {
                Message = "Order Sent",
                Success = true,
                TripDto = tripDto
            };
        }

        public async Task<TripsResponseModel> GetEndedTrips()
        {
            var trips = await _tripRepository.GetEndedTrips();
            if (trips == null)
            {
                return new TripsResponseModel
                {
                    Message = "No trips ended",
                    Success = false
                };
            }
            var tripDtos = trips.Select(t => new TripDTO
            {
                PickUpLocation = t.PickUpLocation,
                DropLocation = t.DropLocation,
                StartTime = t.StartTime,
                EndTime = t.EndTime,
                TripType = t.Type,
                
            }).ToList();
            return new TripsResponseModel
            {
                Message = "List of trips",
                Success = true,
                TripDtos = tripDtos
            };
        }

        public async Task<TripsResponseModel> GetOngoingTrips()
        {
            var trips = await _tripRepository.GetOngoingTrips();
            if (trips.Count == 0)
            {
                return new TripsResponseModel
                {
                    Message = "No trips ongoing",
                    Success = false
                };
            }
            var tripDtos = trips.Select(t => new TripDTO
            {
                PickUpLocation = t.PickUpLocation,
                DropLocation = t.DropLocation,
                StartTime = t.StartTime,
                TripType = t.Type

            }).ToList();
            return new TripsResponseModel
            {
                Message = "List of trips",
                Success = true,
                TripDtos = tripDtos
            };
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> StartTrip(int tripid)
        {
            var trip = await _tripRepository.GetTrip(tripid);
            if (trip.Status == TripStatus.Ongoing)
            {
                return new BaseResponse
                {
                    Message = "Trip started",
                    Success = false
                };
            }
            trip.StartTime = DateTime.UtcNow;
            trip.Status = TripStatus.Ongoing;
            trip.StartTime = DateTime.UtcNow;
            await _tripRepository.Updatetrip(trip);
            return new BaseResponse
            {
                Message = "Trip started successfully",
                Success = true
            };
        }

        public async Task<int> GetOngoingTripsCount()
        {
            var trips = await _tripRepository.GetOngoingTrips();
            int count = 0;
            foreach (var trip in trips)
            {
                count++;
            }
            return count;
        }
    }
}
