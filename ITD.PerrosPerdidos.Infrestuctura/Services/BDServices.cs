using ITD.PerrosPerdidos.Infrestuctura.Repostory.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestuctura.Services
{
    public class BDServices
    {
        private IDbConnection? _dbConnection { get; set; }
        private string? _conection { get; set; }

        public BDServices(IConfiguration configuration)
        {
            _conection = configuration?.GetConnectionString("default");
        }
        private IDbConnection CreateConnection()
        {
            return new sqlConnection(_conection);
        }
        public async ValueTask<IEnumerable<T>> ExecuteStoredProcedureQuery<T>(string storedProcedure, DynamicParameters? parameters = null)
        {
            using (var dbConnection = CreateConnection())
            {
                _dbConnection = dbConnection;
                return (await dbConnection.QueryAsync<T>(storedProcedure,
                parameters, //commandTimeout: (int)BDConfig.timeout,
                commandType: commandType.storedProcedure)).AsQueryable();
            }
        }
        public async ValueTask<T> ExecuteStoredProcedureQueryFirstOrDefault<T>(string storedProcedure, DynamicParameters? parameters = null)
        {
            using (var dbConnection = CreateConnection())
            {
                _dbConnection = dbConnection;
                return await dbConnection.QuerySingleOrDefaultAsync<T>(storedProcedure,
                parameters, //commandTimeout: (int)BDConfig.timeout,
                commandType: commandType.storedProcedure);
            }
        }

    }
}
