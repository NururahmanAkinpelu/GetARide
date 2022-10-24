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
    public class PassengerService : IPassengerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ApplicationContext _context;
        public PassengerService(IUserRepository userRepository, IPassengerRepository passengerRepository, IRoleRepository roleRepository, ApplicationContext context)
        {
            _userRepository = userRepository;
            _passengerRepository = passengerRepository;
            _roleRepository = roleRepository;
            _context = context;
        }

        public async Task<BaseResponse> ActivatePassenger(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passenger = await _passengerRepository.GetPassengerById(id, cancellationToken);
            if (passenger == null)
            {
                return new BaseResponse
                {
                    Message = "User not found",
                    Success = false
                };
            }
            if (passenger != null && passenger.IsDeleted == true)
            {
                passenger.IsDeleted = false;
                return new BaseResponse
                {
                    Message = "User activated",
                    Success = true
                };
            }
            return new BaseResponse
            {
                Message = "User alraedy activated",
                Success = false
            };
        }

        public async Task<BaseResponse> DeactivatePassenger(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passenger = await _passengerRepository.GetPassengerById(id, cancellationToken);
            if (passenger == null)
            {
                return new BaseResponse
                {
                    Message = "User not found",
                    Success = false
                };
            }
            if (passenger != null && passenger.IsDeleted == false)
            {
                passenger.IsDeleted = true;
                await _passengerRepository.UpdatePassenger(passenger, cancellationToken);
                return new BaseResponse
                {
                    Message = "User deactivated",
                    Success = true
                };
            }
            return new BaseResponse
            {
                Message = "User alraedy deaactivated",
                Success = false
            };
        }
    
        public async Task<PassengersResponseModel> GetActivePassengers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passengers = await _passengerRepository.GetActivePassengers(cancellationToken);
            if (passengers == null)
            {
                return new PassengersResponseModel
                {
                    Message = "No admin is activated",
                    Success = false
                };
            }
            var passengerDtos = passengers.Select(a => new PassengerDTO
            {
                Id = a.Id,
                Name = a.Name,
                PhoneNumber = a.PhoneNumber,
                Email = a.Email
            }).ToList();

            return new PassengersResponseModel
            {
                Message = "admin retrieved successfully",
                Success = true,
                PassengerDTOs = passengerDtos
            };

        }

        public async Task<PassengersResponseModel> GetAllPassengers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passengers = await _passengerRepository.GetAllPassengers(cancellationToken);
            if (passengers == null)
            {
                return new PassengersResponseModel
                {
                    Message = "No Passnger registered",
                    Success = false
                };
            }

            var passengerDtos = passengers.Select(a => new PassengerDTO
            {
                Id = a.Id,
                Name = a.Name,
                PhoneNumber = a.PhoneNumber,
                Email = a.Email
            }).ToList();
            return new PassengersResponseModel
            {
                Message = "Passengers gotten",
                Success = true,
                PassengerDTOs = passengerDtos
            };
        }

        public async Task<PassengersResponseModel> GetDeactivatedPassengers(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passengers = await _passengerRepository.GetDeactivatedPassengers(cancellationToken);
            if (passengers == null)
            {
                return new PassengersResponseModel
                {
                    Message = "No admin is deactivated",
                    Success = false
                };
            }
            var passengerDtos = passengers.Select(a => new PassengerDTO
            {
                Id = a.Id,
                Name = a.Name,
                PhoneNumber = a.PhoneNumber,
                Email = a.Email
            }).ToList();

            return new PassengersResponseModel
            {
                Message = "admin retrieved successfully",
                Success = true,
                PassengerDTOs = passengerDtos
            };
        }

        public async Task<PassengerResponseModel> GetPassengerByEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passenger = await _passengerRepository.GetPassengerByEmail(email, cancellationToken);
            if (passenger == null)
            {
                return new PassengerResponseModel
                {
                    Message = "User does not exist",
                    Success = false
                };
            }

            var passengerDto = new PassengerDTO
            {
                Id = passenger.Id,
                Name = passenger.Name,
                PhoneNumber = passenger.PhoneNumber,
                Email = passenger.Email,
            };

            return new PassengerResponseModel
            {
                Message = "admin retrieved succesfully",
                Success = true,
                Data = passengerDto
            };
        }

        public async Task<PassengerResponseModel> GetPassengerById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passenger = await _passengerRepository.GetPassengerById(id, cancellationToken);
            if (passenger == null)
            {
                return new PassengerResponseModel
                {
                    Message = "User does not exist",
                    Success = false
                };
            }

            var passengerDto = new PassengerDTO
            {
                Id = passenger.Id,
                Name = passenger.Name,
                PhoneNumber = passenger.PhoneNumber,
                Email = passenger.Email,
            };

            return new PassengerResponseModel
            {
                Message = "admin retrieved succesfully",
                Success = true,
                Data = passengerDto
            };
        }

        public async Task<PassengerResponseModel> RegisterPassnger(PassengerRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var p = await _passengerRepository.GetPassengerByEmail(model.Email, cancellationToken);
            if (p != null)
            {
                return new PassengerResponseModel
                {
                    Message = "email already exists",
                    Success = false
                };
            }
           
            var user = new User
            {
                FullName = model.Name,
                Email = model.Email,
                Password = model.Password
            };

            Console.WriteLine($"{user.Password}");

            var addUser = await _userRepository.CreateUserAsync(user, cancellationToken);
            var role = await _roleRepository.GetRoleByName("Passenger", cancellationToken);
            if (role == null)
            {
                return new PassengerResponseModel
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
            _context.UserRoles.Add(userRole);
            var updateUser = await _userRepository.UpdateUserAsync(user, cancellationToken);

            var passenger = new Passenger
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserId = addUser.Id,
            };
            var passengerDto = new PassengerDTO
            {
                Id = passenger.Id,
                Name = passenger.Name,
                PhoneNumber = passenger.PhoneNumber,
                Email = passenger.Email,
            };
            var addpassenger = await _passengerRepository.RegisterPassenger(passenger, cancellationToken);

            passenger.CreatedBy = addpassenger.Id;
            passenger.LastModifiedBy = addpassenger.Id;
            passenger.IsDeleted = false;

            await _passengerRepository.UpdatePassenger(passenger, cancellationToken);
            return new PassengerResponseModel
            {
                Message = "passenger Successfully registered",
                Success = true,
                Data = passengerDto
            };
        }

        public async Task<BaseResponse> UpdatePassenger(UpdateAPassengerRequestModel model, int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var passenger = await _passengerRepository.GetPassengerById(id, cancellationToken);
            if (passenger == null)
            {
                return new BaseResponse
                {
                    Message = "User does not exist",
                    Success = false
                };
            }

            var getUser = await _userRepository.GetUserAsync(id, cancellationToken);
            if (getUser == null)
            {
                return new BaseResponse
                {
                    Message = "User does not exist",
                    Success = false
                };
            }
            getUser.Email = model.Email;
            await _userRepository.UpdateUserAsync(getUser, cancellationToken);

            passenger.User.Email = model.Email ?? passenger.User.Email;
            passenger.Name = model.Name;
            passenger.PhoneNumber = model.PhoneNumber ?? passenger.PhoneNumber;
            await _passengerRepository.UpdatePassenger(passenger, cancellationToken);

            return new BaseResponse
            {
                Message = "User successfully updated",
                Success = true
            };
        }
    }
}

