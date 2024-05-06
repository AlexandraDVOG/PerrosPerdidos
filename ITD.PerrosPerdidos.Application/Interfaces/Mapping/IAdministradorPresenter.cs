using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.DTO.Response;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrastructure.Context;
using Newtonsoft.Json.Serialization;


namespace ITD.PerrosPerdidos.Application.Interfaces.Mapping
{
    public interface IAdministradorPresenter

    {
        public List<string> _error { get; set; }


        public ValueTask<AdministradorRe> Get(int code, string usuario, string contrasena, int? celular);
        public ValueTask<AdministradorRe> Post(RAdmin post);

        public Task<AdministradorRe> Patch(int id, PatchAdministradorRequest patch);



    }

}
