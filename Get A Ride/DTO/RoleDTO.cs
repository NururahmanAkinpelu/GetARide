using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleResponseModel : BaseResponse
    {
        public RoleDTO Data { get; set; }
    }

    public class RolesResponseModel : BaseResponse
    {
        public ICollection<RoleDTO> Datas { get; set; } = new HashSet<RoleDTO>();
    }

}
