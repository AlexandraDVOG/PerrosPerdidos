using Dapper;
using ITD.PerrosPerdidos.Aplication.Interfaces.Context;
using ITD.PerrosPerdidos.Infrestuctura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ITD.PerrosPerdidos.Infrestuctura.Repostory.Context.MascotasPerdidasContext;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{

        public class MascotasPerdidasContext : IMascotasPerdidasContext
        {
            private BdContext _BdContext;
            public MascotasPerdidasContext(BdContext BdContext)
            {
            _BdContext = BdContext;
            }

            public async Task<List<MascotasPerdidasContext>> Get(string numero_celular)
            {
            // DynamicParameters dp = new DynamicParameters();
            //dp.Add("@numero_celular", numero_celular, System.DataMisalignedException.DbType.String);
            var result = await _BdContext.ExecuteStoredProcedureQuery<MascotasPerdidasContext>("obtener_publicaciones_recientes", null);
                List < MascotasPerdidasContext > MascotasPerdidasContext = result.ToList();
                if (MascotasPerdidasContext.Count > 0)
                {
                return MascotasPerdidasContext;
                }
            return null;
            }

   
        }
    
}
