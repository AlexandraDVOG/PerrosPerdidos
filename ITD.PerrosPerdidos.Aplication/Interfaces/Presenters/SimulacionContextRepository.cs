using ITD.PerrosPerdidos.Infrestuctura.Repostory.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication.Interfaces.Presenters
{
    public class SimulacionContextRepository : ISimulacionContextRepository
    {
        private readonly BdContext _dbConnection;
        public SimulacionContextRepository(IConfiguration configuration)
        {
            _dbConnection = new BdContext(configuration);

        }
        //public IPermisosContext PermisosContext => new PermisosContext(_dbConnection);

    }
}
