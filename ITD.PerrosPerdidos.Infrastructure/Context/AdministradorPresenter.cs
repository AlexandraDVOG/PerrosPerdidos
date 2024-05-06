﻿using Dapper;
using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Application.Interfaces.Mapping;
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.DTO.Response;
using ITD.PerrosPerdidos.Domain.Enums;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;
using System.Data;

namespace ITD.PerrosPerdidos.Infrastructure.Context
{
    public class AdministradorPresenter: IAdministradorContext
    {
        public ErrorData _errorData { get; set; }
        public readonly BdContext _bDContext;


        public AdministradorPresenter(BdContext services)
        {
            _bDContext = services;
            _errorData = new ErrorData();
        }

        public async Task<List<EntityAdministradorContext>> Get(int code, string usuario, string contrasena, int? celular)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@code", code, DbType.Int32); // Asegúrate de que el tipo de DbType coincide con la definición en la base de datos
            dp.Add("@Usuario", usuario, DbType.String);
            dp.Add("@contrasena", contrasena, DbType.String);
            dp.Add("@celular", celular, DbType.Int32);
         

            var result = await _bDContext.ExecuteStoredProcedureQuery<EntityAdministradorContext>("Obtener Administradores", dp);

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

        public async Task<EntityAdministradorContext> Post(RAdmin post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@usuario", post.data.usuario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@contrasena", post.data.contrasena, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@celular", post.data.celular, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
           
            var result = await _bDContext.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("CrearNuevoAdministrador", dpr);
            if (result.code == 201)
            {
                return new EntityAdministradorContext
                {
                    code = result.code,
                    result = result.result,
                    usuario = post.data.usuario,
                    contrasena = post.data.contrasena,
                    celular = post.data.celular
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
            dp.Add("@usuario", patch.data.usuario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dp.Add("@contrasena", patch.data.contrasena, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dp.Add("@celular", patch.data.celular, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
           

            //var result = await _bDContext.ExecuteStoredProcedureQueryFirstOrDefault<EntityAdministradorContext>("Eventos_UPDATE", dp);

            //if (result.code == 200)
            //{
            //    return result;
            //}
            //else
            //{
            ErrorData _errorData = new ErrorData();
            var result = await _bDContext.ExecuteStoredProcedureQueryFirstOrDefault<EntityAdministradorContext>("Actualizar", dp);
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