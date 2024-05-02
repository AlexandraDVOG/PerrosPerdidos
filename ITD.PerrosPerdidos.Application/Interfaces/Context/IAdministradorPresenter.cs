using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.POCOS.Context;


namespace ITD.PerrosPerdidos.Application.Interfaces.Context
{
    public interface IAdministradorPresenter

    {
        List<string> _error { get; set; }

        //public Task<Administrador_POST> PostAdministrador(Administrador_POST administrador);
        public Task<IEnumerable<Administrador>> Get(string usuario);
        public Task<EntityResultContext> Post(Administrador_POST request);
        //public Task PostAdministrador(Administrador_POST request);
    }
    public interface IAdministradorService

    {

    }
}
