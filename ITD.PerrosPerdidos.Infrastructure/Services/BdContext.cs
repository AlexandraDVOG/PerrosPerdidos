using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ITD.PerrosPerdidos.Infrestructura.Services
{
    public class BdContext
    {
        private IDbConnection? _dbConnection { get; set; }
        private string? _conection { get; set; }
        public BdContext(IConfiguration configuration)
        {
            _conection = configuration?.GetConnectionString("perrosperdios");
        }
        private IDbConnection CreateConnection()
        {
            return new MySqlConnection(_conection);
        }
        public async ValueTask<IEnumerable<T>> ExecuteStoredProcedureQuery<T>(string storedProcedure, DynamicParameters? parameters = null)
        {
            using (var dbConnection = CreateConnection())
            {
                _dbConnection = dbConnection;
                var result = await dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result.AsEnumerable();
            }
        }

        public async ValueTask<T> ExecuteStoredProcedureQueryFirstOrDefault<T>(string storedProcedure, DynamicParameters? parameters = null)

        {
            using (var dbConnection = CreateConnection())
            {
                _dbConnection = dbConnection;
                return await dbConnection.QuerySingleOrDefaultAsync<T>(storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}





//using Dapper;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using MySqlConnector;
//using System.Data;



//namespace ITD.PerrosPerdidos.Infrestructura.Services
//{
//    public class BdContext
//    {
//        private IDbConnection? _dbConnection { get; set; }
//        private string? _conection { get; set; }

//        public BdContext(IConfiguration configuration)
//        {
//            _conection = configuration?.GetConnectionString("DefaultConnection");
//        }

//        private IDbConnection CreateConnection()
//        {
//            //return new SqlConnection(_conection);
//            return new MySqlConnection(_conection);
//        }
//        public async ValueTask<IEnumerable<T>> ExecuteStoredProcedureQuery<T>(string storedProcedure, DynamicParameters? parameters = null)
//        {
//            using (var dbConnection = CreateConnection())
//            {
//                _dbConnection = dbConnection;
//                return (await dbConnection.QueryAsync<T>(storedProcedure,parameters, commandType: CommandType.StoredProcedure)).AsQueryable();
//            }
//        }
//        public async ValueTask<T> ExecuteStoredProcedureQueryFirstOrDefault<T>(string storedProcedure, DynamicParameters? parameters = null)
//        {
//            using (var Connection = CreateConnection())
//            {
//                _dbConnection = Connection;
//                return await Connection.QuerySingleOrDefaultAsync<T>(storedProcedure,
//                 parameters,
//                 commandType: CommandType.StoredProcedure);
//            }
//        }

//    }
//}
