using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface ITripRepository
    {
        public Task<Trip> CreateTrip(Trip trip);
        public Task<Trip> GetTrip(int id );
        public Task<Trip> Updatetrip(Trip trip );
        public Task<ICollection<Trip>> GetOngoingTrips( );
        public Task<ICollection<Trip>> GetEndedTrips( );
        public Task<Trip> GetTripByOrderid(int bookingId);
        /* public Task<Trip> GetTypeOfTrips(CancellationToken cancellationToken);
         public Task<Trip> EndTrip(Trip trip, CancellationToken cancellationToken);*/
    }
}
