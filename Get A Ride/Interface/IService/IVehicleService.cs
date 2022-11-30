using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public  interface IVehicleService
    {
        public Task<BaseResponse> RegisterVehicle(VehicleRequestModel model, int driverId);
        public Task<BaseResponse> UpdateVehicle(UpdateVehicleRequestModel model, int id );
        public Task<BaseResponse> DeleteVehicle(int id);
        public Task<BaseResponse> ApproveVehicle(int id);
        public Task<VehiclesResponseModel> GetAllDriversVehicle(int driverId);
        public Task<int> GetVehiclesCount(int id);

    }
}
