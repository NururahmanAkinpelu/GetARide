using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface ITripService
    {
        public Task<TripResponseModel> CreateTrip(TripRequestModel model );
        public Task<TripResponseModel> MakeReservation(TripRequestModel model);
        public Task<BaseResponse> StartTrip(int tripid);
        public Task<BaseResponse> EndTrip(UpdateTripRequestModel model, int id);
        public Task<TripsResponseModel> GetOngoingTrips( );
        public Task<int> GetOngoingTripsCount();
        public Task<TripsResponseModel> GetEndedTrips( );
    }
}
