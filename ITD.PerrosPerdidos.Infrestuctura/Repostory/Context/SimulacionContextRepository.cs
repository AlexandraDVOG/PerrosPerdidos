using ITD.PerrosPerdidos.Infraestructura;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.ITD.PerrosPerdidos.Infrestuctura;
using Microsoft.Extensions.Configuration;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{

    public class SimulacionContextRepository : ISimulacionContextRepository
        {
            private readonly BdContext _Bd;
        public SimulacionContextRepository(IConfiguration configuration);
                _bd = new BdContext(configuration);
        }
        public IPermisosContext PermisosContext => new PermisosContext(_bd);
    
}
