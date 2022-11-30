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
        public Task<Passenger> RegisterPassenger(Passenger passenger );
        public Task<Passenger> UpdatePassenger(Passenger passenger );
        public Task<ICollection<Passenger>> GetAllPassengers();
        public Task<Passenger> GetPassengerById(int id );
        public Task<Passenger> GetPassengerByUserId(int userId );
        public Task<Passenger> GetPassengerByEmail(string email );
        public Task<ICollection<Passenger>> GetActivePassengers( );
        public Task<ICollection<Passenger>> GetDeactivatedPassengers( );
    }
}
