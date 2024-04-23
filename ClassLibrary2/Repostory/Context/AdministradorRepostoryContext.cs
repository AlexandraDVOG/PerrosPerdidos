using ITD.PerrosPerdidos.Aplication.Interfaces;
using ITD.PerrosPerdidos.Aplication.Interfaces.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;
using Microsoft.Extensions.Configuration;


namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{
    public class AdministradorRepostoryContext :IAdministradorRepositoryContext
    {
        private readonly BdContext _bd;
        public AdministradorRepostoryContext(IConfiguration configuration)
        {
            _bd = new BdContext(configuration);
        }

        public IMascotasPerdidasContext MascotasPerdidasContext => new MascotasPerdidasContext(_bd);
    }
}
