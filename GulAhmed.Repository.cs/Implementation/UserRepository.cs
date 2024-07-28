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
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleUCSPRD") ?? "";
            OracleConfiguration.SqlNetAllowedLogonVersionClient = OracleAllowedLogonVersionClient.Version11;
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
 
                return connection.Query<RoleDTO>("SELECT * FROM GTM_EMP_COMPLETE_V va where va.FULL_NAME like '%Samreen Kiran%'");
            }
        }

        public async Task<DTResult<RoleDTO>> GetEmployeeDataTable(DTParameters DtParams)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                // Construct the SQL query with pagination
                var sqlQuery = @"
            SELECT * 
            FROM (
                SELECT 
                        row_number() over ( order by seqid ) as rnum, t.* 
                FROM 
                    appshr.TIS_tbl_Role t
            ) 
            WHERE 
                rnum BETWEEN :startRowIndex AND :endRowIndex";

                // Calculate start and end row index for pagination
                var startRowIndex = DtParams.Start + 1; // DataTables uses 0-based index
                var endRowIndex = DtParams.Start + DtParams.Length;

                // Execute the query asynchronously
                var result = await connection.QueryAsync<RoleDTO>(sqlQuery, new { startRowIndex, endRowIndex });

                // Get total count of records (for recordsTotal and recordsFiltered)
                var totalCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM appshr.TIS_tbl_Role");

                // Return DTResult with data and counts
                return new DTResult<RoleDTO>
                {
                    data = result.ToList(),
                    recordsTotal = totalCount,
                    draw = DtParams.Draw,
                    recordsFiltered = totalCount // Assuming no filtering is applied in this example
                };
            }
        }
        public RoleDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(RoleDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RoleDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
