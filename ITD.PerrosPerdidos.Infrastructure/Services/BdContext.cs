using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;



namespace ITD.PerrosPerdidos.Infrestructura.Services
{
    public class BdContext
    {
        private IDbConnection? _dbConnection { get; set; }
        private string? _conection { get; set; }

        public BdContext(IConfiguration configuration)
        {
            _conection = configuration?.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_conection);
        }
        public async ValueTask<IEnumerable<T>> ExecuteStoredProcedureQuery<T>(string storedProcedure, DynamicParameters? parameters = null)
        {
            using (var dbConnection = CreateConnection())
            {
                _dbConnection = dbConnection;
                return (await dbConnection.QueryAsync<T>(storedProcedure,
                parameters, //commandTimeout: (int)BDConfig.timeout,
                commandType: CommandType.StoredProcedure)).AsQueryable();
            }
        }
        public async ValueTask<T> ExecuteStoredProcedureQueryFirstOrDefault<T>(string storedProcedure, DynamicParameters? parameters = null)
        {
            using (var Connection = CreateConnection())
            {
                _dbConnection = Connection;
                return await Connection.QuerySingleOrDefaultAsync<T>(storedProcedure,
                 parameters,
                 commandType: CommandType.StoredProcedure);
            }
        }

    }
}
