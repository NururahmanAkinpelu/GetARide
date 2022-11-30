using GetARide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetARide.Authentication
{
    public interface IJWTAuthentication
    {
        public string GenerateToken(UserResponseModel model);
    }
}
