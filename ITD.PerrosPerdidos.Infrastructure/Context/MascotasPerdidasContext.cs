using Dapper;
using ITD.PerrosPerdidos.Aplication.Interfaces.Context;
using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;
using System.Data;


namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{

        public class MascotasPerdidasContext : IMascotasPerdidasContext
        {
            private BdContext _BdContext;
            public MascotasPerdidasContext(BdContext BdContext)
            {
            _BdContext = BdContext;
            }

            public async Task<List<MascotasPerdidasContext>> Get(string celular)
            {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@celular", celular,DbType.String, ParameterDirection.Input);
            var result = await _BdContext.ExecuteStoredProcedureQuery<MascotasPerdidasContext>("ver_administradores", null);
                List < MascotasPerdidasContext > MascotasPerdidasContext = result.ToList();
                if (MascotasPerdidasContext.Count > 0)
                {
                return MascotasPerdidasContext;
                }
            return null;
            }

   
        }
    
}
