using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infraestructura
{
  public class PermisosContext
  {
    public ErrorData ErrorData {get;set;}
    private readonly BdConext _bd;
    public PermisosContext(BdConext bd)
    {
      _bd = bd;
    }
    public async Task<EntityResultConext>Post(RequestPermisos  post)
    {
      DynamicParameters dpr = new DynamicParameters();
      dpr.Add("@usuario", post.data.usuario, System.Data.BdType.String, System.Data.ParameterDirection.Input);
      dpr.Add("@niveles", post.data.niveles, System.Data.BdType.Boolean, System.Data.ParameterDirection.Input);
      dpr.Add("@areas", post.data.areas, System.Data.BdType.Boolean, System.Data.ParameterDirection.Input);

      var result await _bd.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Permisos_Post",dpr);
      return result.code == 201 ? result : null;
      
    }
  }
}
