using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication.Interfaces.Presenters
{
  public class IPermisosPresenter
  {
    public ErrorResponse _errorResponse{get;set;}
    public  ValueTask<PermisosResponse> Post(RequestPermisos post);
  }

}
