using Dapper;
using ITD.PerrosPerdidos.Application.Interfaces;
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestucture.Repostory.Context
{
    public class MascotasPerdidasContext : IMascotasPerdidasContext
    {
        private readonly BdContext _bd;
        public MascotasPerdidasContext(BdContext bd)
        {
            _bd = bd;
        }

        public async Task<string> ModificarCaracteristicasPerroPerdido(int idMascota, string nuevasCaracteristicas)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@p_id_mascota", idMascota, DbType.Int32, ParameterDirection.Input);
            dp.Add("@p_nuevas_caracteristicas", nuevasCaracteristicas, DbType.String, ParameterDirection.Input);
            var result = await _bd.ExecuteStoredProcedureQuery<string>("modificar_caracteristicas_perro_perdido", dp);
            return result.FirstOrDefault();
        }

        public async Task<string> ReportarPerroPerdido(int idUsuario, int celular, string raza, string color, string tamano, char sexo, string caracteristicas, DateTime fechaVisto, string lugarVisto, byte[] imagen)
        {
            DynamicParameters dp = new DynamicParameters();
            // Aquí añades todos los parámetros necesarios para el procedimiento almacenado
            // ...
            var result = await _bd.ExecuteStoredProcedureQuery<string>("reportar_perro_perdido", dp);
            return result.FirstOrDefault();
        }

        public async Task<List<MascotasPerdidasContext>> ObtenerPublicacionesRecientes()
        {
            var result = await _bd.ExecuteStoredProcedureQuery<MascotasPerdidasContext>("obtener_publicaciones_recientes", null);
            return result.ToList();
        }
    }
}

/*
using Dapper;
using ITD.PerrosPerdidos.Application.Interfaces;
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;


namespace ITD.PerrosPerdidos.Infrestucture.Repostory.Context
{
    public class PermisosContext : IPermisosContext
    {
        public ErrorData _errorData { get; set; }
        private readonly BdContext _bd;
        public PermisosContext(BdContext bd)
        {
            _bd = bd;
        }
        public async Task<EntityResultContext> Post(RequestPermisos post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@usuario", post.data.usuario, System.Data.BdType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@niveles", post.data.niveles, System.Data.BdType.Boolean, System.Data.ParameterDirection.Input);
            dpr.Add("@areas", post.data.areas, System.Data.BdType.Boolean, System.Data.ParameterDirection.Input);

            var result = await _bd.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Permisos_Post", dpr);
            if (result.code == 201)
                return result;
            else
            {
                _errorData.code = result.code.ToString();
                _errorData.detail = result.result;
                _errorData.title = "todo se derrumbo";
                _errorData.status = result.code;
                return null;
            }
        }
    }
}
*/