using GulAhmed.TIS.Common.DTO;
using GulAhmed.TIS.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Core.Interface
{
    public interface IAccountService
    {
        public Task<JsonModel> ValidateUser(string Name, string Password);
        public Task<JsonModel> LogoutUser();
    }
}
