using GulAhmed.TIS.Common.DTO;
using GulAhmed.TIS.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Repository.Interface
{
    public interface IAccountRepository
    {


        Task<UserDTO> ValidateUser(string Name, string Password);


    }
}
