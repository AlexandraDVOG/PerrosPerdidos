
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrastructure.Context;

namespace ITD.PerrosPerdidos.Application.Interfaces.Context
{
    public interface IAdministradorContext
    {

        public Task<EntityAdministradorContext> Post(PatchAdministradorRequest post);
    }

}
