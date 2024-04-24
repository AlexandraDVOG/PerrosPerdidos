using ITD.PerrosPerdidos.Aplication.Interfaces;

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
