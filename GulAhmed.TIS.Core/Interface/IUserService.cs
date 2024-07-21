using GulAhmed.TIS.Common.DTO;
using GulAhmed.TIS.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Core.Interface
{
    public interface IUserService
    {

        public Task<DTResult<RoleDTO>> GetEmployeeDataTable(DTParameters dtparam);



    }

}
