using GetARide.Context;
using GetARide.Entities;
using GetARide.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationContext _context;
        public TripRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Trip> CreateTrip(Trip trip, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Trips.AddAsync(trip, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return trip;
        }

        public async Task<Trip> GetTrip(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trip = await _context.Trips.SingleOrDefaultAsync(t => t.Id == id);
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            return trip;
            throw new NotImplementedException();
        }

        public async Task<Trip> Updatetrip(Trip trip, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync(cancellationToken);
            return trip;
        }

        public async Task<ICollection<Trip>> GetOngoingTrips( CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trips = await _context.Trips.Where(t => t.Status == TripStatus.Ongoing).ToListAsync();
            return trips;
        }

        public async Task<ICollection<Trip>> GetEndedTrips(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trips = await _context.Trips.Where(t => t.Status == TripStatus.Ended).ToListAsync();
            return trips;
        }

        /*public async Task<Trip> GetTypeOfTrips(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var trips = await _context.Trips.
            throw new NotImplementedException();
        }

        public async Task<Trip> EndTrip(Trip trip, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }*/
    }
}
