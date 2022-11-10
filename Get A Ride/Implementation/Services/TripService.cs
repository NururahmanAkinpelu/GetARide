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
        public async Task<BaseResponse> EndTrip( int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _tripRepository.GetTrip(id, cancellationToken);
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
            trip.Status = TripStatus.Ended;
            await _tripRepository.Updatetrip(trip, cancellationToken);
            return new BaseResponse
            {
                Message = "trip ended succesfully",
                Success = true
            };
        }

        public async Task<BaseResponse> CreateTrip(TripRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = new Trip
            {
                PickUpLocation = model.PickUpLocation,
                DropLocation = model.DropLocation,
                BookingId = model.BookingId,
                Type = model.TripType
            };
            
            trip.Status = TripStatus.Ongoing;
            await _tripRepository.CreateTrip(trip, cancellationToken);

            return new BaseResponse
            {
                Message = "trip started",
                Success = true
            };
        }

        public async Task<TripsResponseModel> GetEndedTrips(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trips = await _tripRepository.GetEndedTrips(cancellationToken);
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

        public async Task<TripsResponseModel> GetOngoingTrips(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trips = await _tripRepository.GetOngoingTrips(cancellationToken);
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

        public async Task<BaseResponse> StartTrip(int tripid, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _tripRepository.GetTrip(tripid, cancellationToken);
            if (trip.Status == TripStatus.Ongoing)
            {
                return new BaseResponse
                {
                    Message = "Trip started",
                    Success = false
                };
            }
            return new BaseResponse
            {
                Message = "Trip started successfully",
                Success = true
            };
        }
    }
}
