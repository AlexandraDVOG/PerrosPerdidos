using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication.Presenters
{
  public class PermisosPresenter
  {
    private readonly ISimulacionContextRepository _repo;
    PermisosPresenter(ISimulacionContextRepository repo)
    {
      _repo = repo;
    }
    public async ValueTask<PermisosResponse>Post(RequestPermisos post)
    {
      var permisos = await _repo.PermisosContext.Post(post);
      return new PermisosResponse() {data = new PermisosData(){attributes = permisos, type = "permisos"}}
    }
  }
}
