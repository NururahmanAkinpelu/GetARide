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
        public Task<BaseResponse> CreateTrip(TripRequestModel model,  CancellationToken cancellationToken);
        public Task<BaseResponse> StartTrip(int tripid, CancellationToken cancellationToken);
        public Task<BaseResponse> EndTrip( int id, CancellationToken cancellationToken);
        public Task<TripsResponseModel> GetOngoingTrips(CancellationToken cancellationToken);
        public Task<TripsResponseModel> GetEndedTrips(CancellationToken cancellationToken);
    }
}
