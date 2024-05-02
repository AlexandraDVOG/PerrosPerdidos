using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;

namespace ITD.PerrosPerdidos.Infrastructure.Context
{
    public class AdministradorContext : IAdministradorPresenter//*: IAdministradorContext
    {
        private readonly BdContext _bdContext;
        public AdministradorContext(BdContext bdContext) { _bdContext = bdContext; }

        public List<string> _error { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<IEnumerable<Administrador>> Get(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResultContext> Post(Administrador_POST request)
        {
            throw new NotImplementedException();
        }
    }
}
