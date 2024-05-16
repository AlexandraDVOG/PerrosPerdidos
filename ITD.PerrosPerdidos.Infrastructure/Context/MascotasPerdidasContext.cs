//using Dapper;
//using ITD.PerrosPerdidos.Application.Interfaces.Context;
//using ITD.PerrosPerdidos.Infrestructura.Services;
//using System.Data;

//namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
//{
//    public class MascotasPerdidasContext : IMascotasPerdidasContext
//    {
//        private BdContext _BdContext;

//        public List<string> _error { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//        public MascotasPerdidasContext(BdContext BdContext)
//        {
//            _BdContext = BdContext;
//        }

//        public async Task<string> ModificarCaracteristicasPerroPerdido(int idMascota, string nuevasCaracteristicas)
//        {
//            DynamicParameters dp = new DynamicParameters();
//            dp.Add("@p_id_mascota", idMascota, DbType.Int32, ParameterDirection.Input);
//            dp.Add("@p_nuevas_caracteristicas", nuevasCaracteristicas, DbType.String, ParameterDirection.Input);
//            var result = await _BdContext.ExecuteStoredProcedureQuery<string>("modificar_caracteristicas_perro_perdido", dp);
//            return result.FirstOrDefault();
//        }

//        public async Task<string> ReportarPerroPerdido(int idUsuario, int celular, string raza, string color, string tamano, char sexo, string caracteristicas, DateTime fechaVisto, string lugarVisto, byte[] imagen)
//        {
//            DynamicParameters dp = new DynamicParameters();
//            // Aquí añades todos los parámetros necesarios para el procedimiento almacenado
//            // ...
//            var result = await _BdContext.ExecuteStoredProcedureQuery<string>("reportar_perro_perdido", dp);
//            return result.FirstOrDefault();
//        }

//        public async Task<List<MascotasPerdidasContext>> ObtenerPublicacionesRecientes()
//        {
//            var result = await _BdContext.ExecuteStoredProcedureQuery<MascotasPerdidasContext>("obtener_publicaciones_recientes", null);
//            return result.ToList();
//        }

//        public Task<bool> DeleteUsuarioAsync(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

///*using Dapper;
//using ITD.PerrosPerdidos.Aplication.Interfaces.Context;
//using ITD.PerrosPerdidos.Application.Interfaces.Context;
//using ITD.PerrosPerdidos.Infrestructura.Services;
//using System.Data;


//namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
//{

//        public class MascotasPerdidasContext : IMascotasPerdidasContext
//        {
//            private BdContext _BdContext;
//            public MascotasPerdidasContext(BdContext BdContext)
//            {
//            _BdContext = BdContext;
//            }

//            public async Task<List<MascotasPerdidasContext>> Get(string celular)
//            {
//            DynamicParameters dp = new DynamicParameters();
//            dp.Add("@celular", celular,DbType.String, ParameterDirection.Input);
//            var result = await _BdContext.ExecuteStoredProcedureQuery<MascotasPerdidasContext>("ver_administradores", null);
//                List < MascotasPerdidasContext > MascotasPerdidasContext = result.ToList();
//                if (MascotasPerdidasContext.Count > 0)
//                {
//                return MascotasPerdidasContext;
//                }
//            return null;
//            }

   
//        }
    
//}
//*/