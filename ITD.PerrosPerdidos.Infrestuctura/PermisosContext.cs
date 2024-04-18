using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infraestructura
{
  public class PermisosContext
  {
    private readonly BdConext _bd;
    public PermisosContext(BdConext bd)
    {
      _bd = bd;
    }
    public async Task<EntityResultConext>Post()
  }
}
