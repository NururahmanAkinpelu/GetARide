using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface IPassengerService
    {
        public Task<PassengerResponseModel> RegisterPassnger(PassengerRequestModel model, CancellationToken cancellationToken);
        public Task<BaseResponse> UpdatePassenger(UpdateAPassengerRequestModel model, int id, CancellationToken cancellationToken);
        public Task<PassengersResponseModel> GetAllPassengers(CancellationToken cancellationToken);
        public Task<PassengerResponseModel> GetPassengerById(int id, CancellationToken cancellationToken);
        public Task<PassengerResponseModel> GetPassengerByEmail(string email, CancellationToken cancellationToken);
        public Task<BaseResponse> DeactivatePassenger(int id, CancellationToken cancellationToken);
        public Task<BaseResponse> ActivatePassenger(int id, CancellationToken cancellationToken);
        public Task<PassengersResponseModel> GetActivePassengers(CancellationToken cancellationToken);
        public Task<PassengersResponseModel> GetDeactivatedPassengers(CancellationToken cancellationToken);
    }
}
