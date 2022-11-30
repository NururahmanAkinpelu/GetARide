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
        public Task<PassengerResponseModel> RegisterPassnger(PassengerRequestModel model );
        public Task<BaseResponse> UpdatePassenger(UpdateAPassengerRequestModel model, int id );
        public Task<PassengersResponseModel> GetAllPassengers( );
        public Task<PassengerResponseModel> GetPassengerById(int id );
        public Task<PassengerResponseModel> GetPassengerByEmail(string email );
        public Task<BaseResponse> DeactivatePassenger(int id );
        public Task<BaseResponse> ActivatePassenger(int id );
        public Task<PassengersResponseModel> GetActivePassengers( );
        public Task<PassengersResponseModel> GetDeactivatedPassengers();
    }
}
