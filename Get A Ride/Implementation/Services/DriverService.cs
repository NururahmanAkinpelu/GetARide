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

        public async Task<BaseResponse> ActivateDriver(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverRepository.GetDriverByEmail(email, cancellationToken);
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
            return new BaseResponse
            {
                Message = "Driver activated successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> ApproveDriver(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverRepository.GetDriverByEmail(email, cancellationToken);
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
            return new BaseResponse
            {
                Message = "Driver activated successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> DeactivateDriver(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverRepository.GetDriverByEmail(email, cancellationToken);
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
            return new BaseResponse
            {
                Message = "Driver activated successfully",
                Success = true
            };
        }

        public async Task<DriversResponseModel> GetActivatedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverRepository.GetActivatedDrivers(cancellationToken);
            if (drivers == null)
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

        public async Task<DriversResponseModel> GetAllDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverRepository.GetAllDrivers(cancellationToken);
            if (drivers == null)
            {
                return new DriversResponseModel
                {
                    Message = "No driver is registered",
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

        public async Task<DriversResponseModel> GetApprovedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverRepository.GetApprovedDrivers(cancellationToken);
            if (drivers == null)
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

        public async Task<DriversResponseModel> GetDeactivatedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverRepository.GetDeactivaedDrivers(cancellationToken);
            if (drivers == null)
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

        public async Task<DriverResponseModel> GetDriverByEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverRepository.GetDriverByEmail(email, cancellationToken);
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

        public async Task<DriverResponseModel> GetDriverByid(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverRepository.GetDriverById(id, cancellationToken);

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

        public async Task<DriverResponseModel> GetDriverWithVehicle(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverRepository.GetDriverByEmail(email, cancellationToken);

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

        public async Task<DriversResponseModel> GetUnapprovedDrivers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverRepository.GetUnapprovedDrivers(cancellationToken);
            if (drivers == null)
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

        public async Task<DriverResponseModel> RegisterDriver(DriverRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var getdriver = await _driverRepository.GetDriverByEmail(model.Email, cancellationToken);
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
                Password = model.Password,
                Email = model.Email
            };
            var addUser = await _userRepository.CreateUserAsync(user, cancellationToken);
            var role = await _roleRepository.GetRoleByName("Driver", cancellationToken);
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
            await _userRepository.UpdateUserAsync(user, cancellationToken);

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
            var driverDto = new DriverDTO
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                PhoneNumber = driver.PhoneNumber,
                Email = driver.Email,
                Image = driver.Image,
                License = driver.License
            };
            var addDriver = await _driverRepository.RegisterDriver(driver, cancellationToken);
            user.UserRoles.Add(userRole);

            driver.CreatedBy = driver.Id;
            driver.LastModifiedBy = driver.Id;
            driver.IsApproved = false;
            driver.IsDeleted = false;

            await _driverRepository.UpdateDriver(driver, cancellationToken);
            return new DriverResponseModel
            {
                Message = "Driver successfully rgistered",
                Success = true,
                Data = driverDto
            };
        }

        public async Task<BaseResponse> UpdateDriver(UpdateDriverRequestModel model,string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var driver = await _driverRepository.GetDriverByEmail(email, cancellationToken);
            if (driver == null)
            {
                return new BaseResponse
                {
                    Message = "User does not exist",
                    Success = false
                };
            }
            var getuser = await _userRepository.GetUserAsync(driver.UserId, cancellationToken);
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
            await _userRepository.UpdateUserAsync(getuser, cancellationToken);

            driver.FirstName = model.FirstName ?? driver.FirstName;
            driver.LastName = model.LastName ?? driver.LastName;
            driver.PhoneNumber = model.PhoneNumber ?? driver.PhoneNumber;
            driver.Image = model.Image ?? driver.Image;
            driver.License = model.Licence ?? driver.License;
            driver.User.Email = model.Email ?? driver.User.Email;
            driver.User.Password = model.Password ?? driver.Email;
           
            await _driverRepository.UpdateDriver(driver, cancellationToken);

            return new BaseResponse
            {
                Message = "User successfully updated",
                Success = true
            };
            throw new NotImplementedException();
        }

        public async Task<DriversResponseModel> GetAvailableDriver(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var drivers = await _driverRepository.GetAvailableDrivers(cancellationToken);
            if (drivers == null)
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
    }
}
