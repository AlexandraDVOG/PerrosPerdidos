

using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.POCOS.Context;

namespace ITD.PerrosPerdidos.Application.Interfaces
{
    public interface IPermisosContext
    {
        ErrorData _errorData { get; set; }
        public Task<EntityResultContext> Post(RequestPermisos post);
    }
}
