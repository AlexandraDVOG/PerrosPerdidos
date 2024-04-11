using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
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

        }
    }
}
