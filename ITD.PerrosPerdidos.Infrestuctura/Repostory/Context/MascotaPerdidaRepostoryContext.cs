using ITD.PerrosPerdidos.Infrestuctura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ITD.PerrosPerdidos.Infrestuctura.Repostory.Context.MascotaPerdidaRepostoryContext;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{

        public class MascotaPerdidaRepostoryContext : IMascotasPContext
        {
            private BDServices _bDServices;
            public MascotasPerdidasContext(BDService bDService)
            {
                _bDServices = _bDServices;
            }

            public async Task<List<EntityResultContext>> Get(string numero_celular)
            {
                DynamicParameters dp = new();
                dp.Add("@numero_celular", numero_celular, System.DataMisalignedException.DbType.String);
                var result = await _bDServices.ExecuteStoredProcedureQuery < MascotasPerdidasContext >
                List < MascotasPerdidasContext > MascotasPerdidasContext = result.ToList();
                if (MascotasPerdidasContext.Count > 0)
                {
                    switch (MascotasPerdidasContext[0].code)
                    {

                    }
                }
            }

            public async Task<string> Post(MateriasPost request)
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@Usuario", request.usuario, System.Data.DbType.String);
                dp.Add("@contraseña", request.contraseña, System.Data.DbType.String);
                dp.Add("@numero_celular", request.numero_celular, System.Data.DbType.Int32);
                var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Materias_POST", dp);
                return result;
            }
        }
    
}
