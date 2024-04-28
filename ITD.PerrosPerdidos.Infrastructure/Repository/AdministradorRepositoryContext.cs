
using ITD.PerrosPerdidos.Application.Interfaces;
using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.Context;
using Microsoft.Extensions.Configuration;


namespace ITD.PerrosPerdidos.Infrastructure.Repository
{
    public class AdministradorRepositoryContext : IAdministradorRepositoryContext
    {
        private readonly BdContext _bd;
        public AdministradorRepositoryContext(IConfiguration configuration)
        {
            _bd = new BdContext(configuration);
        }

        public IMascotasPerdidasContext MascotasPerdidasContext => new MascotasPerdidasContext(_bd);
    }
}
