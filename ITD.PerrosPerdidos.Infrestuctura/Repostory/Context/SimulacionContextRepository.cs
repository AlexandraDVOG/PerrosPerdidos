﻿using ITD.PerrosPerdidos.Aplication.Interfaces;
using ITD.PerrosPerdidos.Infraestructura;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.Context;

using Microsoft.Extensions.Configuration;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
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
