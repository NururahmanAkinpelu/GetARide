using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface IDriverService
    {
        public Task<DriverResponseModel> RegisterDriver(DriverRequestModel model );
        public Task<BaseResponse> UpdateDriver(UpdateDriverRequestModel model, string email );
        public Task<BaseResponse> ApproveDriver(int id );
        public Task<BaseResponse> ActivateDriver(int id );
        public Task<BaseResponse> DeactivateDriver(int id );
        public Task<DriverResponseModel> GetDriverByid(int id );
        public Task<DriverResponseModel> GetDriverByEmail(string email );
        public Task<DriverResponseModel> GetDriverWithVehicle(string email );
        public Task<DriversResponseModel> GetUnapprovedDrivers( );
        public Task<int> GetUnapprovedDriversCount();
        public Task<DriversResponseModel> GetApprovedDrivers( );
        public Task<DriversResponseModel> GetActivatedDrivers( );
        public Task<DriversResponseModel> GetDeactivatedDrivers( );
        public Task<DriversResponseModel> GetAvailableDriver( );
    }
}
