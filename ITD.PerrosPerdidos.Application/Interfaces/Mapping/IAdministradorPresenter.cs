using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrastructure.Context;
using Newtonsoft.Json.Serialization;


namespace ITD.PerrosPerdidos.Application.Interfaces.Mapping
{
    public interface IAdministradorPresenter

    {
        public List<string> _error { get; set; }


        public ValueTask<AdministradorRe> Get(int code, string usuario, string contrasena, int? celular);

        public Task<EntityAdministradorContext> Post(AdministradorRe post);
        public Task<EntityAdministradorContext> Patch(PatchAdministradorRequest patch);
      

    }

}
