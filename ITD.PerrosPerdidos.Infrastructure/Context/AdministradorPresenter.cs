using Dapper;
using ITD.PerrosPerdidos.Application.Interfaces.Mapping;
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.Enums;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;
using System.Data;

namespace ITD.PerrosPerdidos.Infrastructure.Context
{
    public class AdministradorPresenter : IAdministradorPresenter//*: IAdministradorContext
    {
        public ErrorData _errorData { get; set; }
        public readonly BdContext _bDContext;


        public AdministradorPresenter(BdContext services)
        {
            _bDContext = services;
            _errorData = new ErrorData();
        }

        public async Task<List<EntityAdministradorContext>> Get(int code, string nombre, string fecha, string hora, string ubicacion, string descripcion)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@code", code, DbType.Int32); // Asegúrate de que el tipo de DbType coincide con la definición en la base de datos
            dp.Add("@nombre", nombre, DbType.String);
            dp.Add("@fecha", fecha, DbType.String);
            dp.Add("@hora", hora, DbType.String);
            dp.Add("@ubicacion", ubicacion, DbType.String);
            dp.Add("@descripcion", descripcion, DbType.String);

            var result = await _bDContext.ExecuteStoredProcedureQuery<EntityAdministradorContext>("ObtenerEventosDiario", dp);

            if (result.Any())
            {
                switch (result.First().code)
                {
                    case (int)StatusHttp.Success: return result.ToList();
                    case (int)StatusHttp.badRequest: return new List<EntityAdministradorContext>();
                    default: return new List<EntityAdministradorContext>();
                }
            }

            return new List<EntityAdministradorContext>();
        }

        public async Task<EntityAdministradorContext> Post(AdministradorRe post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@nombre", post.data.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@fecha", post.data.fecha, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@hora", post.data.hora, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@ubicacion", post.data.ubicacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@descripcion", post.data.descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDContext.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("CrearNuevoEventoDiario", dpr);
            if (result.code == 201)
            {
                return new EntityAdministradorContext
                {
                    code = result.code,
                    result = result.result,
                    nombre = post.data.nombre,
                    fecha = post.data.fecha,
                    hora = post.data.hora,
                    ubicacion = post.data.ubicacion,
                    descripcion = post.data.descripcion
                };
            }
            else
            {
                _errorData.code = result.code;
                _errorData.title = "Todo se derrumbo";
                _errorData.detail = result.result;
                _errorData.status = result.code.ToString();

                return null;

            }
        }
        public async Task<EntityAdministradorContext> Patch(PatchAdministradorRequest patch)
        {
            // crear clase 
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", patch.data.id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dp.Add("@nombre", patch.data.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dp.Add("@fecha", patch.data.fecha, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dp.Add("@hora", patch.data.hora, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dp.Add("@ubicacion", patch.data.ubicacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dp.Add("@descripcion", patch.data.descripcion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //var result = await _bDContext.ExecuteStoredProcedureQueryFirstOrDefault<EntityAdministradorContext>("Eventos_UPDATE", dp);

            //if (result.code == 200)
            //{
            //    return result;
            //}
            //else
            //{
            ErrorData _errorData = new ErrorData();
            var result = await _bDContext.ExecuteStoredProcedureQueryFirstOrDefault<EntityAdministradorContext>("ActualizarEventoDiario", dp);
            if (result.code == 200)
                return result;
            else
            {
                // Manejo de errores si la actualización falla
                _errorData.code = result.code;
                _errorData.title = "Error de actualización";
                _errorData.detail = result.result;
                _errorData.status = result.code.ToString();

                return null;
            }

        }
    }
}