using GetARide.Context;
using GetARide.DTO;
using GetARide.Entities.Identity;
using GetARide.Interface.IRepository;
using GetARide.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ApplicationContext _context;
        public  VehicleService(IVehicleRepository vehicleRepository, ApplicationContext context)
        {
            _vehicleRepository = vehicleRepository;
            _context = context;
        }
        public async Task<BaseResponse> DeleteVehicle(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var vehicle = await _vehicleRepository.GetVehicleById(id, cancellationToken);
            if (vehicle == null)
            {
                return new BaseResponse
                {
                    Message = "Vehicle does not exist",
                    Success = false
                };
            }
            vehicle.IsDeleted = true;

            return new BaseResponse
            {
                Message = "Vehicle removed successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> RegisterVehicle(VehicleRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var getVehicle = await _vehicleRepository.GetVehicleByPlateNumber(model.PlateNumber, cancellationToken);
            if (getVehicle != null)
            {
                return new BaseResponse
                {
                    Message = "Vehicle alraedy registered",
                    Success = false
                };
            }

            var vehicle = new Vehicle
            {
                Name = model.Name,
                Model = model.Model,
                Colour = model.Colour,
                PlateNumber = model.PlateNumber,
                Documents = model.Documents,
                DriverId = model.DriverId
            };
            var addVehicle = await _vehicleRepository.RegisterVehicle(vehicle, cancellationToken);
            vehicle.CreatedBy = addVehicle.DriverId;
            vehicle.LastModifiedBy = addVehicle.DriverId;
            vehicle.IsDeleted = false;
            vehicle.IsApproved = false;

            await _vehicleRepository.UpdateVehicle(vehicle, cancellationToken);

            return new BaseResponse
            {
                Message = "Vehicle Registered Succesfully",
                Success = true
            };
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> ApproveVehicle(int id, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleById(id, cancellationToken);
            if (vehicle == null)
            {
                return new BaseResponse
                {
                    Message = "Vehicle does not exist",
                    Success = false
                };
            }
            if (vehicle != null && vehicle.IsApproved == true)
            {
                return new BaseResponse
                {
                    Message = "Vehicle already approved",
                    Success = false
                };
            }
            vehicle.IsApproved = true;
            return new BaseResponse
            {
                Message = "Vehicle approved successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> UpdateVehicle(UpdateVehicleRequestModel model, int id, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleById(id, cancellationToken);
            if (vehicle != null)
            {
                return new BaseResponse
                {
                    Message = "Vehicle does not exist",
                    Success = false
                };
            }
            vehicle.Name = model.Name;
            vehicle.Colour = model.Colour;
            vehicle.Model = model.Model;
            vehicle.PlateNumber = model.PlateNumber;
            vehicle.Documents = model.Documents;

            await _vehicleRepository.UpdateVehicle(vehicle, cancellationToken);
            return new BaseResponse
            {
                Message = "Vehicle updated successfully",
                Success = true
            };
        }
    }
}
