  using ITD.PerrosPerdidos.Application.Interfaces.Presenters;
using ITD.PerrosPerdidos.Domain.Enums;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _permisosPresenter.GetPermisoByIdAsync(id);
            if (_permisosPresenter._error.Count > 0)
            {
                return BadRequest(_permisosPresenter._error);
            }
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestPermisos post)
        {
            var result = await _permisosPresenter.Post(post);
            if (result != null)
                return Created("www.google.com", result);
            return BadRequest(_permisosPresenter);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<RequestPermisos> patchDoc)
        {
            if (patchDoc != null)
            {
                var permiso = await _permisosPresenter.GetPermisoByIdAsync(id);

                if (permiso == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(permiso, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool result = await _permisosPresenter.UpdatePermisoAsync(permiso);

                if (!result)
                {
                    return BadRequest("Error al actualizar el permiso");
                }

                return new ObjectResult(permiso);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}


/*using ITD.PerrosPerdidos.Application.Interfaces.Presenters;
using ITD.PerrosPerdidos.Domain.Enums;
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

        public PermisosController(PermisosPresenter permisosPresenter)
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
*/