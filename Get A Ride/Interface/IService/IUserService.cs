using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Interface.IService
{
    public interface IUserService
    {
        public Task<UserResponseModel> Login(UserRequestModel model, CancellationToken cancellationToken);
    }
}
