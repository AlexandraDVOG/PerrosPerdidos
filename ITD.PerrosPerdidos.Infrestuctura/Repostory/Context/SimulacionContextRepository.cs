public class SimulacionContextRepository : ISimulacionContextRepository
{
private readonly BdContext _Bd;
public SimulacionContextRepository(IConfiguration configuration)
_bd = new BdContext(configuration);
}
public IPermisosContext PermisosContext => new PermisosContext(_bd);
