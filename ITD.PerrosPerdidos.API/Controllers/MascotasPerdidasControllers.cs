

using ITD.PerrosPerdidos.Application.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;


namespace ITD.PerrosPerdidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MascotasPerdidasControllers : ControllerBase
    {
        private readonly IMascotasPerdidasContext _mascotasPerdidas;

        public MascotasPerdidasControllers(IMascotasPerdidasContext mascotasPerdidas)
        {
            _mascotasPerdidas = mascotasPerdidas;
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Delete(int id)
        {
            // Lógica para eliminar el usuario con el ID proporcionado
            var result = await _mascotasPerdidas.DeleteUsuarioAsync(id);

            if (_mascotasPerdidas._error.Count > 0)
            {
                return BadRequest(_mascotasPerdidas._error);
            }

            return result ? Ok() : NotFound(); // Si el usuario fue eliminado correctamente, devuelve Ok. De lo contrario, NotFound.
        }
    }
}


//using ITD.PerrosPerdidos.Application.Interfaces.Context;
//using ITD.PerrosPerdidos.Application.Presenter;
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Mime;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace ITD.PerrosPerdidos.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Produces(MediaTypeNames.Application.Json)]
//    [Consumes(MediaTypeNames.Application.Json)]
//    public class MascotasPerdidasControllers : ControllerBase
//    {


//        private readonly IMascotasPerdidasPresenter _mascotasPerdidas;

//        public MascotasPerdidasControllers(IMascotasPerdidasContext mascotasPerdidas)
//        {
//            _mascotasPerdidas = mascotasPerdidas;
//        }
//        [HttpDelete("{id}")]
//        [Produces(MediaTypeNames.Application.Json)]
//        [Consumes(MediaTypeNames.Application.Json)]
//        public async Task<IActionResult> Delete(int id)
//        {
//            // Lógica para eliminar el usuario con el ID proporcionado
//            var result = await _mascotasPerdidas.DeleteUsuarioAsync(id);

//            if (_mascotasPerdidas._error.Count > 0)
//            {
//                return BadRequest(_mascotasPerdidas._error);
//            }

//            return result ? Ok() : NotFound(); // Si el usuario fue eliminado correctamente, devuelve Ok. De lo contrario, NotFound.
//        }

//    }
//}

