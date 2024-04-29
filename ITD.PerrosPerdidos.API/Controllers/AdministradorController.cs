using ITD.PerrosPerdidos.Application.Interfaces.Presenters;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorPresenter _administradorPresenter;

        public AdministradorController(IAdministradorPresenter administradorPresenter)
        {
            _administradorPresenter = administradorPresenter;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get(string telefono)
        {
            var result = await _administradorPresenter.Administrador_GETAsync(telefono);
            if (_administradorPresenter._error.Count > 0)
            {
                return BadRequest(_administradorPresenter._error);
            }
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Administrador_POST administrador)
        {
            var result = await _administradorService.PostAdministrador(administrador);
            if (result != null)
            {
                return Ok(new { message = "Administrador agregado exitosamente." });
            }
            else
            {
                return BadRequest(new { message = "Ocurrió un error al agregar el administrador." });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Administrador_POST> patchDoc)
        {
            if (patchDoc != null)
            {
                var administrador = await _administradorPresenter.GetAdministradorByIdAsync(id);

                if (administrador == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(administrador, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool result = await _administradorPresenter.UpdateAdministradorAsync(administrador);

                if (!result)
                {
                    return BadRequest("Error al actualizar el administrador");
                }

                return new ObjectResult(administrador);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}


/*using ITD.PerrosPerdidos.Application.Interfaces.Presenters;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ITD.PerrosPerdidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorPresenter _administradorPresenter;



        public AdministradorController(IAdministradorPresenter administradorPresenter)
        {
            _administradorPresenter = administradorPresenter;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get(string telefono)
        {
            var result = await _administradorPresenter.Administrador_GETAsync(telefono);
            if (_administradorPresenter._error.Count > 0)
            {
                return BadRequest(_administradorPresenter._error);
            }
            return result != null ? Ok(result) : NotFound();
        }

      
    public async Task<IActionResult> Post([FromBody] Administrador_POST administrador)
    {
        var result = await _administradorService.PostAdministrador(administrador);
        if (result != null)
        {
            return Ok(new { message = "Administrador agregado exitosamente." });
        }
        else
        {
            return BadRequest(new { message = "Ocurrió un error al agregar el administrador." });
        }
    }
}
}
*/