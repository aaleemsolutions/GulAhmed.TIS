using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GulAhmed.TIS.Common.Helpers.Enumeration;

namespace GulAhmed.TIS.Common.DTO
{
    public class RoleDTO: BaseDTO
    {
       
        public string Role_Name { get; set; }
        public UserType RoleType { get; set; }
        public Boolean IsActive { get; set; }
        

    }
}
