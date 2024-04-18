using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace ITD.PerrosPerdidos.Aplication.Interfaces.Context
{
  public interface IPermisosContext
  {
    ErrorData _errorData {get;set;}
    public Task<EntityResultContext>Post(RequestPermisos post);
  }
}
