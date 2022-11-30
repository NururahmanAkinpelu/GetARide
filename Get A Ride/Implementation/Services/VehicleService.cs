using GetARide.Context;
using GetARide.DTO;
using GetARide.Entities.Identity;
using GetARide.Interface.IRepository;
using GetARide.Interface.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Implementation.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ApplicationContext _context;
        public  VehicleService(IVehicleRepository vehicleRepository, IUserRepository userRepository, IDriverRepository driverRepository, ApplicationContext context)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _driverRepository = driverRepository;
            _context = context;
        }

        public async Task<BaseResponse> DeleteVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleById(id);
            if (vehicle == null)
            {
                return new BaseResponse
                {
                    Message = "Vehicle does not exist",
                    Success = false
                };
            }
            await _vehicleRepository.DeleteVehicle(vehicle);

            return new BaseResponse
            {
                Message = "Vehicle removed successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> RegisterVehicle(VehicleRequestModel model, int driverId = 27)
        {

            var getVehicle = await _vehicleRepository.GetVehicleByPlateNumber(model.PlateNumber);
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
                Type = model.Type,
                DriverId = driverId
            };
            var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "//Document//");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (model.Documents != null)
            {

                var fileName = Path.GetFileNameWithoutExtension(model.Documents.FileName);
                var filePath = Path.Combine(folderPath, model.Documents.FileName);
                var extension = Path.GetExtension(model.Documents.FileName);
                if (!Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Documents.CopyToAsync(stream);
                    }
                    vehicle.Documents = fileName;
                }
            }
            var addVehicle = await _vehicleRepository.RegisterVehicle(vehicle);
            vehicle.CreatedBy = addVehicle.DriverId;
            vehicle.LastModifiedBy = addVehicle.DriverId;
            vehicle.IsDeleted = false;
            vehicle.IsApproved = false;
         

            return new BaseResponse
            {
                Message = "Vehicle Registered Succesfully",
                Success = true
            };
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> ApproveVehicle(int id )
        {
            var vehicle = await _vehicleRepository.GetVehicleById(id);
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

        public async Task<BaseResponse> UpdateVehicle(UpdateVehicleRequestModel model, int id )
        {
            var vehicle = await _vehicleRepository.GetVehicleById(id);
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

            await _vehicleRepository.UpdateVehicle(vehicle);
            return new BaseResponse
            {
                Message = "Vehicle updated successfully",
                Success = true
            };
        }

        public async Task<VehiclesResponseModel> GetAllDriversVehicle(int userId)
        {
            var driver = await _userRepository.GetUserAsync(userId);
            var vehicles = await _vehicleRepository.GetAllDriversVehicles(driver.Id);
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
                    Id = v.Id,
                    Name = v.Name,
                    Model = v.Model,
                    Colour = v.Colour,
                    PlateNumber = v.PlateNumber,
                    Documents = v.Documents,
                    Type = v.Type

                }).ToList()
            };
            
        }

        public async Task<int> GetVehiclesCount(int id)
        {
            var vehicles = await _vehicleRepository.GetAllDriversVehicles(id);
            int count = 0;
            foreach (var vehicle in vehicles)
            {
                count++;
            }
            return count;
        }
    }
}
