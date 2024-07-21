using GulAhmed.TIS.Common.DTO;
using GulAhmed.TIS.Common.Model;
using GulAhmed.TIS.Core.Interface;
using GulAhmed.TIS.Repository.Interface;

namespace GulAhmed.TIS.Core.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<DTResult<RoleDTO>> GetEmployeeDataTable(DTParameters dtparam)
        {
            try
            {
                var users = await this.userRepository.GetEmployeeDataTable(dtparam);
                return users;
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
    }
}
