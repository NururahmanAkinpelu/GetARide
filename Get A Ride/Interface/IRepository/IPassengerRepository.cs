using GetARide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IRepository
{
    public interface IPassengerRepository
    {
        public Task<Passenger> RegisterPassenger(Passenger passenger, CancellationToken cancellationToken);
        public Task<Passenger> UpdatePassenger(Passenger passenger, CancellationToken cancellationToken);
        public Task<ICollection<Passenger>> GetAllPassengers(CancellationToken cancellationToken);
        public Task<Passenger> GetPassengerById(int id, CancellationToken cancellationToken);
        public Task<Passenger> GetPassengerByEmail(string email, CancellationToken cancellationToken);
        public Task<ICollection<Passenger>> GetActivePassengers(CancellationToken cancellationToken);
        public Task<ICollection<Passenger>> GetDeactivatedPassengers(CancellationToken cancellationToken);
    }
}
