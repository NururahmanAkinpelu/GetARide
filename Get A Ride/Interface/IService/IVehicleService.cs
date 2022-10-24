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
        public Task<BaseResponse> RegisterVehicle(VehicleRequestModel model, CancellationToken cancellationToken);
        public Task<BaseResponse> UpdateVehicle(UpdateVehicleRequestModel model, int id, CancellationToken cancellationToken);
        public Task<BaseResponse> DeleteVehicle(int id, CancellationToken cancellationToken);
        public Task<BaseResponse> ApproveVehicle(int id, CancellationToken cancellationToken);
    }
}
