
using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.Enums;
using Microsoft.AspNetCore.Mvc;


namespace ITD.PerrosPerdidos.Application.Interfaces.Presenters
{
    public class PermisosPresenter : IPermisosPresenter
    {
        public ErrorResponse _errorResponse { get; set; }
        private readonly IAdministradorRepositoryContext _repo;
        PermisosPresenter(IAdministradorRepositoryContext repo)
        {
            _errorResponse = new ErrorResponse();
            _repo = repo;
        }

        [ProducesResponseType(typeof(List<AreasResponse>), (int)StatusHttp.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusHttp.badRequest)]

        public async ValueTask<PermisosResponse> Post(RequestPermisos post)
        {
            var permisos = await _repo.PermisosContext.Post(post);
            if (permisos.code = 201)
                return new PermisosResponse() { data = new PermisosData() { attributes = new PermisosAttributes() { mensaje = permisos.result }, type = "permisos" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = permisos.code.ToString(), detail = permisos.result, status = permisos.code, title = "Mejor date de baja" } };
            return null;
        }
    }
}
