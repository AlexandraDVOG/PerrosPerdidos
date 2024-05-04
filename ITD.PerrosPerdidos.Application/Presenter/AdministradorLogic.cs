using ITD.PerrosPerdidos.Application.Interfaces.Mapping;
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Infrastructure.Context;



namespace ITD.PerrosPerdidos.Application.Interfaces
{
    public class AdministradorLogic : IAdministradorPresenter
    {
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }

        private readonly IAdministradorRepositoryContext _eventosRepository;


        public AdministradorLogic(IAdministradorRepositoryContext eventosRepository)

        {
            _eventosRepository = eventosRepository;
            _error = new List<string>();
            _errorResponse = new ErrorResponse();

        }


        public async ValueTask<AdministradorRe> Get(int code, string usuario, string contrasena, int? celular)
        {
            var eventosResult = await _eventosRepository.AdministradorPresenter.Get(code, usuario, contrasena, celular);

            List<AdministradorAtributes> dT0s = eventosResult.Select(evento => new AdministradorAtributes
            {
                code = evento.code,
                result = evento.result ?? "", // Asignar cadena vacía si result es nulo
                usuario = evento.usuario,
                contrasena = evento.contrasena,
                celular = evento.celular
            }).ToList();

            AdministradorData eventData = new AdministradorData
            {
                attributes = dT0s,
                type = "usuario"
            };

            return new AdministradorRe { data = eventData };
        }


        public async ValueTask<AdministradorRe> Post(AdministradorRe post)
        {
            // crear response y 
            var evento = await _eventosRepository.AdministradorPresenter.Post(post);
            if (evento.code == 201)
                return new AdministradorRe()
                {
                    data = new AdministradorData()
                    {
                        attributes = new List<AdministradorAtributes>
                        {
            new AdministradorAtributes { result = evento.result }
        },
                        type = "eventos"
                    }
                };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = evento.code, detail = evento.result, status = evento.usuario, title = "Todo se derrumbo" } };
            return null;
        }

        public async Task<AdministradorRe> Patch(int id, PatchAdministradorRequest patch)
        {
            if (id <= 0)
            {
                _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = 400, detail = "ID de usuario no válido", status = "400", title = "Error" } };
                return null;
            }

            if (patch == null || patch.data == null)
            {
                _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = 400, detail = "Los datos son nulos", status = "400", title = "Error" } };
                return null;
            }


            var result = await _eventosRepository.AdministradorPresenter.Patch(patch);

            if (result == null)
            {
                _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = 500, detail = "Error al procesar la solicitud", status = "500", title = "Error" } };
                return null;
            }

            return new AdministradorRe() { data = new AdministradorData() { attributes = new List<AdministradorAtributes>() { new() { result = result.result } }, type = "eventos" } };
        }
    }
}