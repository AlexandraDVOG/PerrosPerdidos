using ITD.PerrosPerdidos.Application.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PerrosPerdidosControllercs : ControllerBase
    {
        private readonly AdministradorLogic _administrador;

        public PerrosPerdidosControllercs(AdministradorLogic administrador)
        {
            _administrador = administrador;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]

        
        public async Task<IActionResult> Get(string telefono)
        {
            var result = await _administrador.Usuarios_GETAsync(telefono);
            if (_administrador._error.Count > 0)
            {
                return BadRequest(_administrador._error);
            }
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.DTO.DATA.RequestPermisos post)
        {
            var result = await _administrador.PostAdministrador(post);
            if (result != null)
            {
                return Created("www.google.com", result);
            }
            return BadRequest(_administrador);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<RequestPermisos> patchDoc)
        {
            if (patchDoc != null)
            {
                var permiso = await _administrador.GetPermisoByIdAsync(id);

                if (permiso == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(permiso, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool result = await _administrador.UpdatePermisoAsync(permiso);

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


/*using ITD.PerrosPerdidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mime;


namespace ITD.PerrosPerdidos.API.Controllers

{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]

    public class PerrosPerdidosControllercs : ControllerBase
    {
        private readonly AdministradorLogic _administrador;



        public PerrosPerdidosControllercs(AdministradorLogic administrador)
        {
            _administrador = administrador;
            
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get(string telefono)
        {
            var result = await _administrador.Usuarios_GETAsync(telefono);
            if (_administrador._error.Count > 0)
            {
                return BadRequest(_administrador._error);
            }
            return result != null ? Ok(result) : NotFound(); //Si tuviera un POST se debe poner Create en Ok
        }
    }
}
*/