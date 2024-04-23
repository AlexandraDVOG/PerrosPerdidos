using ITD.PerrosPerdidos.Aplication.Interfaces.Presenters;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITD.PerrosPerdidos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes("application/json")]

    [ProducesResponseType(typeof(PermisosResponse), (int)StatusHttp.badRequest)]

    public class PermisosController : ControllerBase
    {
        private readonly IPermisosPresenter _permisosPresenter;

        public PermisosController(IPermisosPresenter permisosPresenter)
        {
            _permisosPresenter = permisosPresenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PermisosResponse), (int)StatusHttp.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusHttp.BadRequest)]
        public async Task<IActionResult> Post(RequestPermisos post)
        {
            var result = await _permisosPresenter.Post(post);
            if (result != null)
                return Created("www.google.com", result);
            return BadRequest(_permisosPresenter);
        }
    }
}
