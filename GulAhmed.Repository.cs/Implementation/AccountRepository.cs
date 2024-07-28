using Dapper;
using GulAhmed.TIS.Common.DTO;
using GulAhmed.TIS.Common.Model;
using GulAhmed.TIS.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Repository.Implementation
{
    public class AccountRepository : IAccountRepository
    {

        private readonly string _connectionString;

        public AccountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleUCSPRD") ?? "";
            OracleConfiguration.SqlNetAllowedLogonVersionClient = OracleAllowedLogonVersionClient.Version11;
        }

        public async Task<UserDTO> ValidateUser(string Name, string Password)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var model = await connection.QueryAsync<UserDTO>("SELECT * FROM appshr.TIS_TBL_USERs where ISACTIVE = 1 and USERNAME = '" + Name + "' and PASSWORD = '" + Password + "'");
                return  model.FirstOrDefault() ?? new UserDTO();
            }
        }

        
    }
}
