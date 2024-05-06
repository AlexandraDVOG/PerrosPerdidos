

using ITD.PerrosPerdidos.Application.Interfaces.Mapping;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.DTO.Response;
using ITD.PerrosPerdidos.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;


namespace ITD.PerrosPerdidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorPresenter EPresenter;

        public AdministradorController(IAdministradorPresenter _eventosPresenter)
        {
            EPresenter = _eventosPresenter;
        }

        [HttpGet]
        [Route("/[controller]")]
        [ProducesResponseType(typeof(List<RequestAdministrador>), 200)]
        [ProducesResponseType(typeof(ProducesErrorResponseTypeAttribute), 400)]

        public async Task<IActionResult> Get(int code, string usuario, string contrasena, int? celular)
        
        {
            var result = await EPresenter.Get(code, usuario, contrasena, celular);

            return Ok(result);
        }

        [HttpPost]
        [Route("/[controller]")]
        [ProducesResponseType(typeof(List<RequestAdministrador>), 201)]
        [ProducesResponseType(typeof(ProducesErrorResponseTypeAttribute), 400)]

        public async Task<IActionResult> Post(RAdmin post)


        {

            var result = await EPresenter.Post(post);
            if (result == null)
                return Created("www.google.com", result);
            return BadRequest(EPresenter._error);
        }

        [HttpPatch]
        [Route("/api/{id}/[controller]")]
        [ProducesResponseType(typeof(RequestAdministrador), 200)]
        [ProducesResponseType(typeof(ProducesErrorResponseTypeAttribute), 400)]
        public async Task<IActionResult> Patch(int id, PatchAdministradorRequest patch)
        {

            var result = await EPresenter.Patch(id, patch);
            if (result == null)
            {
                return BadRequest(EPresenter._error);
            }
            return Created("www.google.com", result);
        }
    }
}