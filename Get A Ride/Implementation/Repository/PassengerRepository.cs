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
    public class PassengerRepository : IPassengerRepository
    {
        public ApplicationContext _context;

        public PassengerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task <ICollection<Passenger>> GetAllPassengers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passengers = await _context.Passengers.Include(p => p.User).ToListAsync();
            return passengers;
        }

        public async Task<Passenger> GetPassengerByEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passenger = await _context.Passengers.Where(p => p.User.Email.ToLower() == email.ToLower()).SingleOrDefaultAsync(cancellationToken);
            return passenger;
        }

        public async Task<Passenger> GetPassengerById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var passenger = await _context.Passengers.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            return passenger;
        }

        public async Task<Passenger> RegisterPassenger(Passenger passenger, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Passengers.AddAsync(passenger, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return passenger;
        }

        public async Task<Passenger> UpdatePassenger(Passenger passenger, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Update(passenger);
            await _context.SaveChangesAsync(cancellationToken);
            return passenger;
        }

        public async Task<ICollection<Passenger>> GetActivePassengers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passengers = await _context.Passengers.Include(p => p.User).Where(x => x.IsDeleted == false).ToListAsync();
            return passengers;
        }

        public async Task<ICollection<Passenger>> GetDeactivatedPassengers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passengers = await _context.Passengers.Include(x => x.User).Where(x => x.IsDeleted == true).ToListAsync();
            return passengers;
        }
    }
}
