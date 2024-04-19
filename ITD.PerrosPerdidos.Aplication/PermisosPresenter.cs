using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication.Presenters
{
  public class PermisosPresenter
  {
    public ErrorResponse _errorResponse {get;set}
    private readonly ISimulacionContextRepository _repo;
    PermisosPresenter(ISimulacionContextRepository repo)
    {
      _errorResponse = new ErrorResponse();
      _repo = repo;
    }
    public async ValueTask<PermisosResponse>Post(RequestPermisos post)
    {
      var permisos = await _repo.PermisosContext.Post(post);
      if (permisos.code = 201)
        return new PermisosResponse() {data = new PermisosData(){attributes = new PermisosAttributes() {mensaje = permisos.result}, type = "permisos"}};  
      _errorResponse.errors = new List<ErrorData>(){new ErrorData(){code = permisos.code.ToString(), detail = permisos.result, status = permisos.code, title = "todo se derrumbo"}}; 
      return null;
    }
  }
}
