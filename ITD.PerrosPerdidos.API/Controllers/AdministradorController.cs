using ITD.PerrosPerdidos.Aplication.Interfaces.Presenters;
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
        public async Task<IActionResult> Get(string nombre, string telefono)
        {
            var result = await _administradorPresenter.Administrador_GETAsync(telefono);
            if (_administradorPresenter._error.Count > 0)
            {
                return BadRequest(_administradorPresenter._error);
            }
            return result != null ? Ok(result) : NotFound();
        }
    }
}