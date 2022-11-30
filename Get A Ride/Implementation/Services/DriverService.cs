using GetARide.Context;
using GetARide.DTO;
using GetARide.Entities;
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
    public class DriverService:IDriverService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ApplicationContext _context;
        public DriverService(IUserRepository userRepository, IDriverRepository driverRepository, IRoleRepository roleRepository, ApplicationContext context)
        {
            _userRepository = userRepository;
            _driverRepository = driverRepository;
            _roleRepository = roleRepository;
            _context = context;
        }

        public async Task<BaseResponse> ActivateDriver(int id )
        {
        
            var driver = await _driverRepository.GetDriverById(id);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "Driver does not exist",
                    Success = false
                };
            }
            if (driver != null && driver.IsDeleted == true)
            {
                return new BaseResponse
                {
                    Message = "Driver is already activated",
                    Success = false
                };
            }
            driver.IsDeleted = true;
            await _driverRepository.UpdateDriver(driver);
            return new BaseResponse
            {
                Message = "Driver activated successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> ApproveDriver(int id )
        {
            var driver = await _driverRepository.GetDriverById(id);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "Driver does not exist",
                    Success = false
                };
            }
            if (driver != null && driver.IsApproved == true)
            {
                return new BaseResponse
                {
                    Message = "Driver is already approved",
                    Success = false
                };
            }
            driver.IsApproved = true;
            await _driverRepository.UpdateDriver(driver);
            return new BaseResponse
            {
                Message = "Driver approved successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> DeactivateDriver(int id)
        {
            var driver = await _driverRepository.GetDriverById(id);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "Driver does not exist",
                    Success = false
                };
            }
            if (driver != null && driver.IsDeleted == true)
            {
                return new BaseResponse
                {
                    Message = "Driver is already deactivated",
                    Success = false
                };
            }
            driver.IsDeleted = true;
            await _driverRepository.UpdateDriver(driver);
            
            return new BaseResponse
            {
                Message = "Driver deactivated successfully",
                Success = true
            };
        }

        public async Task<DriversResponseModel> GetActivatedDrivers( )
        {
            var drivers = await _driverRepository.GetActivatedDrivers();
            if (drivers.Count == 0)
            {
                return new DriversResponseModel
                {
                    Message = "No driver is activated",
                    Success = false
                };
            }
            var driversDto = drivers.Select(d => new DriverDTO
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Image = d.Image,
                PhoneNumber = d.PhoneNumber,
                Email =d.Email
            }).ToList();

            return new DriversResponseModel
            {
                Message = "Drivers gotten",
                Success = true,
                Data = driversDto
            };
        }

        public async Task<DriversResponseModel> GetApprovedDrivers()
        {
            var drivers = await _driverRepository.GetApprovedDrivers();
            if (drivers.Count == 0)
            {
                return new DriversResponseModel
                {
                    Message = "No driver is approved",
                    Success = false
                };
            }
            var driversDto = drivers.Select(d => new DriverDTO
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Image = d.Image,
                PhoneNumber = d.PhoneNumber,
                Email = d.Email
            }).ToList();

            return new DriversResponseModel
            {
                Message = "Drivers gotten",
                Success = true,
                Data = driversDto
            };
        }

        public async Task<DriversResponseModel> GetDeactivatedDrivers()
        {
            var drivers = await _driverRepository.GetDeactivaedDrivers();
            if (drivers.Count == 0)
            {
                return new DriversResponseModel
                {
                    Message = "No driver is deactivated",
                    Success = false
                };
            }
            var driversDto = drivers.Select(d => new DriverDTO
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Image = d.Image,
                PhoneNumber = d.PhoneNumber,
                Email = d.Email,
            }).ToList();

            return new DriversResponseModel
            {
                Message = "Drivers gotten",
                Success = true,
                Data = driversDto
            };
        }

        public async Task<DriverResponseModel> GetDriverByEmail(string email )
        {
            var driver = await _driverRepository.GetDriverByEmail(email);
            if (driver == null)
            {
                return new DriverResponseModel
                {
                    Message = "driver does not exist",
                    Success = false
                };
            }
            var driverDto = new DriverDTO
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Image = driver.Image,
                PhoneNumber = driver.PhoneNumber,
                Email = driver.Email,
                License = driver.License
            };
            return new DriverResponseModel
            {
                Message = "Driver gotten",
                Success = true,
                Data = driverDto
            };
        }

        public async Task<DriverResponseModel> GetDriverByid(int id )
        {
            var driver = await _driverRepository.GetDriverById(id);

            if (driver == null)
            {
                return new DriverResponseModel
                {
                    Message = "driver does not exist",
                    Success = false
                };
            }
            var driverDto = new DriverDTO
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Image = driver.Image,
                PhoneNumber = driver.PhoneNumber,
                Email = driver.Email,
                License = driver.License
            };
            return new DriverResponseModel
            {
                Message = "Driver gotten",
                Success = true,
                Data = driverDto
            };
        }

        public async Task<DriverResponseModel> GetDriverWithVehicle(string email)
        {
            var driver = await _driverRepository.GetDriverByEmail(email);

            if (driver == null)
            {
                return new DriverResponseModel
                {
                    Message = "driver does not exist",
                    Success = false
                };
            }
            var driverDto = new DriverDTO
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Image = driver.Image,
                PhoneNumber = driver.PhoneNumber,
                Email = driver.Email,
                License = driver.License,
                Vehicles = driver.Vehicles
            };
            return new DriverResponseModel
            {
                Message = "Driver gotten",
                Success = true,
                Data = driverDto
            };
        }

        public async Task<DriversResponseModel> GetUnapprovedDrivers()
        {
            var drivers = await _driverRepository.GetUnapprovedDrivers();
            if (drivers.Count == 0)
            {
                return new DriversResponseModel
                {
                    Message = "No driver is unapproved",
                    Success = false
                };
            }
            var driversDto = drivers.Select(d => new DriverDTO
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Image = d.Image,

                PhoneNumber = d.PhoneNumber,

                Email = d.Email,
                License = d.License
            }).ToList();

            return new DriversResponseModel
            {
                Message = "Drivers gotten",
                Success = true,
                Data = driversDto
            };
        }

        public async Task<DriverResponseModel> RegisterDriver(DriverRequestModel model )
        { 
            var getdriver = await _driverRepository.GetDriverByEmail(model.Email);
            if (getdriver != null)
            {
                return new DriverResponseModel
                {
                    Message = "Driver already exists",
                    Success = false
                };
            }
            var user = new User
            {
                FullName = $"{model.FirstName} {model.LastName}",
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Email = model.Email
            };
            var addUser = await _userRepository.CreateUserAsync(user);
            var role = await _roleRepository.GetRoleByName("Driver");
            if (role == null)
            {
                return new DriverResponseModel
                {
                    Message = "Role not found",
                    Success = false
                };
            }
            var userRole = new UserRoles
            {
                UserId = addUser.Id,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);
            await _userRepository.UpdateUserAsync(user);

            var driver = new Driver
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Image = model.Image,
                License = model.Licence,
                UserId = user.Id
            };
           
            var addDriver = await _driverRepository.RegisterDriver(driver);
            var driverDto = new DriverDTO
            {
                Id = addDriver.Id,
                FirstName = addDriver.FirstName,
                LastName = addDriver.LastName,
                PhoneNumber = addDriver.PhoneNumber,
                Email = addDriver.Email,
                Image = addDriver.Image,
                License = addDriver.License
            };
            user.UserRoles.Add(userRole);

            driver.CreatedBy = driver.Id;
            driver.LastModifiedBy = driver.Id;
            driver.IsApproved = false;
            driver.IsDeleted = false;

            await _driverRepository.UpdateDriver(driver);
            return new DriverResponseModel
            {
                Message = "Driver successfully rgistered",
                Success = true,
                Data = driverDto
            };
        }

        public async Task<BaseResponse> UpdateDriver(UpdateDriverRequestModel model,string email)
        {
            var driver = await _driverRepository.GetDriverByEmail(email);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "User does not exist",
                    Success = false
                };
            }
            var getuser = await _userRepository.GetUserAsync(driver.UserId);
            if (getuser == null)
            {
                return new BaseResponse()
                {
                    Success = false,
                    Message = "User not found"
                };
            }
            getuser.Email = model.Email;
            getuser.Password = model.Password;
            await _userRepository.UpdateUserAsync(getuser);

            driver.FirstName = model.FirstName ?? driver.FirstName;
            driver.LastName = model.LastName ?? driver.LastName;
            driver.PhoneNumber = model.PhoneNumber ?? driver.PhoneNumber;
            driver.Image = model.Image ?? driver.Image;
            driver.License = model.Licence ?? driver.License;
            driver.User.Email = model.Email ?? driver.User.Email;
            driver.User.Password = model.Password ?? driver.Email;
           
            await _driverRepository.UpdateDriver(driver);

            return new BaseResponse
            {
                Message = "User successfully updated",
                Success = true
            };
            throw new NotImplementedException();
        }

        public async Task<DriversResponseModel> GetAvailableDriver()
        {
            var drivers = await _driverRepository.GetAvailableDrivers();
            if (drivers.Count == 0)
            {
                return new DriversResponseModel
                {
                    Message = "No available drivers",
                    Success = false
                };
            }
            var driversDtos = drivers.Select(d => new DriverDTO
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                Image = d.Image,
                PhoneNumber = d.PhoneNumber,
            }).ToList();
            return new DriversResponseModel
            {
                Message = "AvailableDrivers",
                Success = true,
                Data = driversDtos
            };
        }

        public async Task<int> GetUnapprovedDriversCount()
        {
            int count = 0;
            var drivers = await _driverRepository.GetUnapprovedDrivers();
            foreach (var driver in drivers)
            {
                count++;
            }
            return count;
        }
    }
}
