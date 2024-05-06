
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.DTO.Response;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrastructure.Context;

namespace ITD.PerrosPerdidos.Application.Interfaces.Context
{
    public interface IAdministradorContext
    {

        public Task<EntityAdministradorContext> Patch(PatchAdministradorRequest patch);
        public Task<EntityAdministradorContext> Post(RAdmin post);
        public  Task<List<EntityAdministradorContext>> Get(int code, string usuario, string contrasena, int? celular);

    }

}
