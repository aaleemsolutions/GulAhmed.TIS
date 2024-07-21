using GulAhmed.TIS.Common.DTO;
using GulAhmed.TIS.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<RoleDTO> GetAll();
        Task<DTResult<RoleDTO>> GetEmployeeDataTable(DTParameters DtParams);
        RoleDTO Get(int id);
        void Add(RoleDTO entity);
        void Update(RoleDTO entity);
        void Delete(RoleDTO entity);
    }
}
