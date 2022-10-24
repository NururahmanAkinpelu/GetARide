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
        public Task<Trip> CreateTrip(Trip trip, CancellationToken cancellationToken);
        public Task<Trip> GetTrip(int id, CancellationToken cancellationToken);
        public Task<Trip> Updatetrip(Trip trip, CancellationToken cancellationToken);
        public Task<ICollection<Trip>> GetOngoingTrips(CancellationToken cancellationToken);
        public Task<ICollection<Trip>> GetEndedTrips(CancellationToken cancellationToken);
        /* public Task<Trip> GetTypeOfTrips(CancellationToken cancellationToken);
         public Task<Trip> EndTrip(Trip trip, CancellationToken cancellationToken);*/
    }
}
