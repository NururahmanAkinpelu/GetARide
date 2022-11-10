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
        public Task<DriverResponseModel> RegisterDriver(DriverRequestModel model, CancellationToken cancellationToken);
        public Task<BaseResponse> UpdateDriver(UpdateDriverRequestModel model, string email, CancellationToken cancellationToken);
        public Task<BaseResponse> ApproveDriver(int id, CancellationToken cancellationToken);
        public Task<BaseResponse> ActivateDriver(int id, CancellationToken cancellationToken);
        public Task<BaseResponse> DeactivateDriver(int id, CancellationToken cancellationToken);
        public Task<DriversResponseModel> GetAllDrivers(CancellationToken cancellationToken);
        public Task<DriverResponseModel> GetDriverByid(int id, CancellationToken cancellationToken);
        public Task<DriverResponseModel> GetDriverByEmail(string email, CancellationToken cancellationToken);
        public Task<DriverResponseModel> GetDriverWithVehicle(string email, CancellationToken cancellationToken);
        public Task<DriversResponseModel> GetUnapprovedDrivers(CancellationToken cancellationToken);
        public Task<DriversResponseModel> GetApprovedDrivers(CancellationToken cancellationToken);
        public Task<DriversResponseModel> GetActivatedDrivers(CancellationToken cancellationToken);
        public Task<DriversResponseModel> GetDeactivatedDrivers(CancellationToken cancellationToken);
        public Task<DriversResponseModel> GetAvailableDriver(CancellationToken cancellationToken);
    }
}
