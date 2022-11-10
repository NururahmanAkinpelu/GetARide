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
        private readonly IUserRepository _userRepository;
        private readonly ApplicationContext _context;
        public  VehicleService(IVehicleRepository vehicleRepository, IUserRepository userRepository, ApplicationContext context)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
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

        public async Task<BaseResponse> RegisterVehicle(VehicleRequestModel model, CancellationToken cancellationToken, int driverId = 27)
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
                Type = model.Type,
                DriverId = driverId
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
            vehicle.Model = model.Model;
            vehicle.Colour = model.Colour;
            vehicle.PlateNumber = model.PlateNumber;
            vehicle.Documents = model.Documents;

            await _vehicleRepository.UpdateVehicle(vehicle, cancellationToken);
            return new BaseResponse
            {
                Message = "Vehicle updated successfully",
                Success = true
            };
        }

        public async Task<VehiclesResponseModel> GetAllDriversVehicle(int userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _userRepository.GetUserAsync(userId, cancellationToken);
            var vehicles = await _vehicleRepository.GetAllDriversVehicles(driver.Id, cancellationToken);
            if (vehicles.Count == 0)
            {
                return new VehiclesResponseModel
                {
                    Message = "This Driver no get any vehicle o",
                    Success = false
                };
            }
            return new VehiclesResponseModel
            {
                Message = "List of vehicles",
                Success = true,
                Data = vehicles.Select(v => new VehicleDTO
                {
                    Name = v.Name,
                    Model = v.Model,
                    Colour = v.Colour,
                    PlateNumber = v.PlateNumber,
                    Type = v.Type,

                }).ToList()
            };
            
        }
    }
}
