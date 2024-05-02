


//using Dapper;
//using ITD.PerrosPerdidos.Application.Interfaces;
//using ITD.PerrosPerdidos.Application.Interfaces.Context;
//using ITD.PerrosPerdidos.Domain.DTO.DATA;
//using ITD.PerrosPerdidos.Domain.DTO.Requests;
//using ITD.PerrosPerdidos.Domain.POCOS.Context;
//using ITD.PerrosPerdidos.Infrestructura.Services;


//namespace ITD.PerrosPerdidos.Infrestucture.Repostory.Context
//{
//    public class PermisosContext : IPermisosContext
//    {
//        public ErrorData _errorData { get; set; }
//        private readonly BdContext _bd;
//        public PermisosContext(BdContext bd)
//        {
//            _bd = bd;
//        }
//        public async Task<EntityResultContext> Post(AdministradorData post)
//        {
//            DynamicParameters dpr = new DynamicParameters();
//            dpr.Add("@usuario", post.data.usuario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
//            dpr.Add("@telefono", post.data.celular, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
//            dpr.Add("@contrase�a", post.data.contraseña, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);

//            var result = await _bd.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Permisos_Post", dpr);
//            if (result.code == 201)
//                return result;
//            else
//            {
//                _errorData.code = result.code.ToString();
//                _errorData.detail = result.result;
//                _errorData.title = "todo se derrumbo";
//                _errorData.status = result.code.ToString();
//                return null;
//            }
//        }

//        public Task<EntityResultContext> Post(RequestPermisos post)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
